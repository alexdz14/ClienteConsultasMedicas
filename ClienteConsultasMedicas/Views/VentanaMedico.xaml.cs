using System.Windows;
using ClienteConsultasMedicas.Views.ControlesMedico;

namespace ClienteConsultasMedicas.Views
{
    public partial class VentanaMedico : Window
    {
        public VentanaMedico()
        {
            InitializeComponent();
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
