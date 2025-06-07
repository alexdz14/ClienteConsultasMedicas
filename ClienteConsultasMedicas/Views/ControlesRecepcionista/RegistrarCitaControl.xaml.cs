using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using ClienteConsultasMedicas.Models;
using ClienteConsultasMedicas.Services;

namespace ClienteConsultasMedicas.Views.ControlesRecepcionista
{
    public partial class RegistrarCitaControl : UserControl
    {
        public RegistrarCitaControl()
        {
            InitializeComponent();
        }

        private async void RegistrarCita_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPacienteId.Text) ||
                string.IsNullOrWhiteSpace(txtMedicoId.Text) ||
                string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            // Validar que el usuario haya seleccionado una fecha
            if (dpFechaHora.Value == null)
            {
                MessageBox.Show("Debes seleccionar una fecha y hora.");
                return;
            }

            DateTime fechaHora = dpFechaHora.Value.Value;

            if (fechaHora < DateTime.Now)
            {
                MessageBox.Show("No puedes registrar una cita en el pasado.");
                return;
            }

            // 💬 DEBUG: Mostrar qué fecha se está enviando
            MessageBox.Show("Fecha enviada: " + fechaHora.ToString("yyyy-MM-dd HH:mm:ss"));

            var cita = new CitaNueva
            {
                pacienteId = txtPacienteId.Text,
                medicoId = txtMedicoId.Text,
                motivo = txtMotivo.Text,
                fechaHora = fechaHora
            };

            bool ok = await ApiService.RegistrarCitaAsync(cita);

            if (ok)
            {
                MessageBox.Show("Cita registrada exitosamente.");
                txtPacienteId.Text = "";
                txtMedicoId.Text = "";
                txtMotivo.Text = "";
                dpFechaHora.Value = DateTime.Now;
            }
            else
            {
                MessageBox.Show("Error al registrar cita.");
            }
        }
    }
}
