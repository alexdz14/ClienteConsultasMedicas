using ClienteConsultasMedicas.Models;
using ClienteConsultasMedicas.Services;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ClienteConsultasMedicas.Views.ControlesRecepcionista
{
    public partial class VerCitasControl : UserControl
    {
        private List<CitaResumen> citas = new();
        private CitaResumen? citaSeleccionada = null;

        public VerCitasControl()
        {
            InitializeComponent();
            CargarCitas();
        }

        private async void CargarCitas()
        {
            citas = await ApiService.ObtenerTodasCitasAsync();
            dgCitas.ItemsSource = citas;
        }

        private void dgCitas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            citaSeleccionada = dgCitas.SelectedItem as CitaResumen;

            if (citaSeleccionada == null)
            {
                btnCancelar.IsEnabled = false;
            }
            else
            {
                btnCancelar.IsEnabled = citaSeleccionada.estado != "cancelada";
            }
        }


        private async void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (citaSeleccionada == null)
            {
                MessageBox.Show("Selecciona una cita primero.");
                return;
            }

            var confirm = MessageBox.Show("¿Seguro que deseas cancelar esta cita?", "Confirmar",
                                          MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (confirm == MessageBoxResult.Yes)
            {
                bool ok = await ApiService.CancelarCitaAsync(citaSeleccionada.id);
                if (ok)
                {
                    MessageBox.Show("Cita cancelada.");
                    CargarCitas();
                }
                else
                {
                    MessageBox.Show("Error al cancelar la cita.");
                }
            }
        }
    }
}
