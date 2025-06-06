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
        }

        private async void BuscarHistorial_Click(object sender, RoutedEventArgs e)
        {
            string pacienteId = txtBuscarPacienteId.Text;

            List<ConsultaHistorial> historial = await ApiService.ObtenerHistorialPorPacienteAsync(pacienteId);

            if (historial.Count == 0)
            {
                MessageBox.Show("No se encontraron consultas para ese paciente.");
            }

            dgHistorial.ItemsSource = historial;
        }
    }
}
