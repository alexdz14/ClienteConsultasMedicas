using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClienteConsultasMedicas.Services;
using ClienteConsultasMedicas.Views.ControlesRecepcionista;

namespace ClienteConsultasMedicas.Views
{
    public partial class VentanaRecepcionista : Window
    {
        public VentanaRecepcionista()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bool conectado = await ApiService.HayConexionAsync();
            txtBannerOffline.Visibility = conectado ? Visibility.Collapsed : Visibility.Visible;

            btnCitas.IsEnabled = conectado;
            btnVerCitas.IsEnabled = conectado;
            btnVerPacientes.IsEnabled = conectado;
            btnDashboard.IsEnabled = conectado;

            ActualizarContadorPendientes();
        }



        private void BtnPacientes_Click(object sender, RoutedEventArgs e)
        {
            contenido.Content = new ControlesRecepcionista.RegistrarPacienteControl();
        }

        private void BtnCitas_Click(object sender, RoutedEventArgs e)
        {
            contenido.Content = new ControlesRecepcionista.RegistrarCitaControl();
        }

        private void BtnVerPacientes_Click(object sender, RoutedEventArgs e)
        {
            contenido.Content = new ControlesRecepcionista.VerPacientesControl();
        }

        private void BtnDashboard_Click(object sender, RoutedEventArgs e)
        {
            contenido.Content = new DashboardControl();
        }

        private void BtnVerCitas_Click(object sender, RoutedEventArgs e)
        {
            contenido.Content = new ControlesRecepcionista.VerCitasControl();
        }

        private async void BtnSincronizar_Click(object sender, RoutedEventArgs e)
        {
            if (!await ApiService.HayConexionAsync())
            {
                MessageBox.Show("No hay conexión para sincronizar.", "Modo sin conexión", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int sincronizados = await PacienteOfflineService.SincronizarPendientesAsync(true); 

            if (sincronizados > 0)
            {
                MessageBox.Show($"✅ Se sincronizaron {sincronizados} pacientes correctamente.", "Sincronización completa");
            }
            else
            {
                MessageBox.Show("No hay pacientes pendientes por sincronizar.", "Sincronización");
            }

            ActualizarContadorPendientes();
        }

        private void ActualizarContadorPendientes()
        {
            int pendientes = PacienteOfflineService.ContarPendientes();

            if (pendientes > 0)
            {
                lblPendientes.Text = $" {pendientes} pacientes sin sincronizar";
                lblPendientes.Visibility = Visibility.Visible;
            }
            else
            {
                lblPendientes.Visibility = Visibility.Collapsed;
            }
        }


        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }
    }
}
