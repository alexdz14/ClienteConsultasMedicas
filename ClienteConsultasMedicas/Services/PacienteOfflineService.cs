using ClienteConsultasMedicas.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ClienteConsultasMedicas.Services
{
    public static class PacienteOfflineService
    {
        private static string dbPath = "pacientes_offline.db";

        static PacienteOfflineService()
        {
            if (!File.Exists(dbPath))
            {
                CrearBaseDeDatos();
            }
        }

        public static int ContarPendientes()
        {
            using var conexion = new SqliteConnection($"Data Source={dbPath}");
            conexion.Open();

            using var cmd = conexion.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM pacientes WHERE sincronizado = 0";

            return Convert.ToInt32(cmd.ExecuteScalar());
        }


        private static void CrearBaseDeDatos()
        {
            using var conexion = new SqliteConnection($"Data Source={dbPath}");
            conexion.Open();

            var comando = conexion.CreateCommand();
            comando.CommandText =
            @"
                CREATE TABLE IF NOT EXISTS pacientes (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    nombre TEXT NOT NULL,
                    email TEXT NOT NULL,
                    telefono TEXT NOT NULL,
                    sincronizado INTEGER NOT NULL
                );
            ";
            comando.ExecuteNonQuery();
        }

        public static void GuardarPaciente(Paciente paciente)
        {
            using var conexion = new SqliteConnection($"Data Source={dbPath}");
            conexion.Open();

            var comando = conexion.CreateCommand();
            comando.CommandText =
            @"
                INSERT INTO pacientes (nombre, email, telefono, sincronizado)
                VALUES ($nombre, $email, $telefono, $sincronizado);
            ";

            comando.Parameters.AddWithValue("$nombre", paciente.nombre);
            comando.Parameters.AddWithValue("$email", paciente.email);
            comando.Parameters.AddWithValue("$telefono", paciente.telefono);
            comando.Parameters.AddWithValue("$sincronizado", 0); // 0 = false

            comando.ExecuteNonQuery();
        }

        public static List<Paciente> ObtenerPendientes()
        {
            var lista = new List<Paciente>();

            using var conexion = new SqliteConnection($"Data Source={dbPath}");
            conexion.Open();

            var comando = conexion.CreateCommand();
            comando.CommandText = "SELECT nombre, email, telefono FROM pacientes WHERE sincronizado = 0";

            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                lista.Add(new Paciente
                {
                    nombre = lector.GetString(0),
                    email = lector.GetString(1),
                    telefono = lector.GetString(2),
                    sincronizado = false
                });
            }

            return lista;
        }

        public static async Task<int> SincronizarPendientesAsync(bool mostrarMensaje = false)
        {
            var pendientes = ObtenerPendientes();
            int sincronizados = 0;

            foreach (var paciente in pendientes)
            {
                bool ok = await ApiService.RegistrarPacienteAsync(paciente);
                if (ok)
                {
                    MarcarComoSincronizado(paciente.email);
                    sincronizados++;
                }
            }

            if (mostrarMensaje && sincronizados > 0)
            {
                MessageBox.Show($"Se sincronizaron {sincronizados} pacientes.", "Sincronización");
            }

            return sincronizados;
        }

        private static void MarcarComoSincronizado(string email)
        {
            using var conexion = new SqliteConnection($"Data Source={dbPath}");
            conexion.Open();

            var comando = conexion.CreateCommand();
            comando.CommandText = "UPDATE pacientes SET sincronizado = 1 WHERE email = $email";
            comando.Parameters.AddWithValue("$email", email);
            comando.ExecuteNonQuery();
        }

    }
}
