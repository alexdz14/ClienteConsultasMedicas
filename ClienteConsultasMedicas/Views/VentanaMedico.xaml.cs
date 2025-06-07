using System.Windows;
using ClienteConsultasMedicas.Services;
using ClienteConsultasMedicas.Views.ControlesMedico;

namespace ClienteConsultasMedicas.Views
{
    public partial class VentanaMedico : Window
    {
        public VentanaMedico()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bool conectado = await ApiService.HayConexionAsync();
            txtBannerOffline.Visibility = conectado ? Visibility.Collapsed : Visibility.Visible;

            btnCitas.IsEnabled = conectado;
            btnRegistrar.IsEnabled = conectado;
            btnHistorial.IsEnabled = conectado;
        }


        private void BtnCitas_Click(object sender, RoutedEventArgs e)
        {
            contenido.Content = new CitasAsignadasControl();
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            contenido.Content = new RegistrarConsultaControl();
        }

        private void BtnHistorial_Click(object sender, RoutedEventArgs e)
        {
            contenido.Content = new HistorialClinicoControl();
        }

        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            var login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}
