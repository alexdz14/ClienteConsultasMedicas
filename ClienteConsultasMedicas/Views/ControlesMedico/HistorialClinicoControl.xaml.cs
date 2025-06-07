using ClienteConsultasMedicas.Models;
using ClienteConsultasMedicas.Services;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ClienteConsultasMedicas.Views.ControlesMedico
{
    public partial class HistorialClinicoControl : UserControl
    {
        public HistorialClinicoControl()
        {
            InitializeComponent();
            CargarPacientes();
        }

        private async void CargarPacientes()
        {
            var pacientes = await ApiService.ObtenerPacientesAsync();
            cmbPacientes.ItemsSource = pacientes;
        }


        private async void BuscarHistorial_Click(object sender, RoutedEventArgs e)
        {
            if (cmbPacientes.SelectedItem is not PacienteItem pacienteSeleccionado)
            {
                MessageBox.Show("Selecciona un paciente.");
                return;
            }

            string pacienteId = pacienteSeleccionado.id;

            List<ConsultaHistorial> historial = await ApiService.ObtenerHistorialPorPacienteAsync(pacienteId);

            foreach (var consulta in historial)
            {
                consulta.fechaHora = consulta.fechaHora.ToLocalTime();
            }

            if (historial.Count == 0)
            {
                MessageBox.Show("No se encontraron consultas para ese paciente.");
            }

            dgHistorial.ItemsSource = historial;
        }


    }
}
