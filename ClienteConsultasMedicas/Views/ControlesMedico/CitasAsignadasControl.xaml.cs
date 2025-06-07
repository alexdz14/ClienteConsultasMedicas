using ClienteConsultasMedicas.Models;
using ClienteConsultasMedicas.Services;
using ClienteConsultasMedicas.Utils;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ClienteConsultasMedicas.Views.ControlesMedico
{
    public partial class CitasAsignadasControl : UserControl
    {
        public CitasAsignadasControl()
        {
            InitializeComponent();
            CargarCitas();
        }

        private List<Cita> todasCitas = new();

        private async void CargarCitas()
        {
            todasCitas = await ApiService.ObtenerCitasDelMedicoAsync();
            AplicarFiltro();
        }

        private void chkHoy_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            AplicarFiltro();
        }

        private void chkHoy_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            AplicarFiltro();
        }

        private void AplicarFiltro()
        {
            if (chkHoy.IsChecked == true)
            {
                dgCitas.ItemsSource = todasCitas
                    .FindAll(c => c.fechaHora.Date == DateTime.Today && c.estado != "cancelada");
            }
            else
            {
                dgCitas.ItemsSource = todasCitas;
            }
        }

    }
}
