using ClienteConsultasMedicas.Models;
using ClienteConsultasMedicas.Services;
using ClienteConsultasMedicas.Utils;
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

        private void BtnExportarPDF_Click(object sender, RoutedEventArgs e)
        {
            if (dgHistorial.Items.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            var historial = dgHistorial.Items.OfType<ConsultaHistorial>().ToList();

            string? nombrePaciente = (cmbPacientes.SelectedItem as PacienteItem)?.nombre ?? "Paciente";

            bool exito = PDFHelper.ExportarHistorial(historial, nombrePaciente);

            if (exito)
            {
                MessageBox.Show("PDF exportado correctamente en tu escritorio.");
            }
            else
            {
                MessageBox.Show("Hubo un error al generar el PDF.");
            }
        }
    }
}
