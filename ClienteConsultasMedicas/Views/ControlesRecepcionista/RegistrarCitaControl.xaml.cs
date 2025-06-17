using System;
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
            Loaded += RegistrarCitaControl_Loaded;
        }

        private async void RegistrarCitaControl_Loaded(object sender, RoutedEventArgs e)
        {
            var pacientes = await ApiService.ObtenerPacientesDesdeUsuariosAsync();
            var medicos = await ApiService.ObtenerMedicosAsync();

            cmbPacientes.ItemsSource = pacientes;
            cmbMedicos.ItemsSource = medicos;
        }

        private async void RegistrarCita_Click(object sender, RoutedEventArgs e)
        {
            if (cmbPacientes.SelectedValue == null ||
                cmbMedicos.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

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

            var cita = new CitaNueva
            {
                pacienteId = cmbPacientes.SelectedValue.ToString(),
                medicoId = cmbMedicos.SelectedValue.ToString(),
                motivo = txtMotivo.Text,
                fechaHora = fechaHora
            };

            bool ok = await ApiService.RegistrarCitaAsync(cita);

            if (ok)
            {
                MessageBox.Show("Cita registrada exitosamente.");
                cmbPacientes.SelectedIndex = -1;
                cmbMedicos.SelectedIndex = -1;
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
