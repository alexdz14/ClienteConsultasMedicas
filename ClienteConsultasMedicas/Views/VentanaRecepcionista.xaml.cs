using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using ClienteConsultasMedicas.Views.ControlesRecepcionista;

namespace ClienteConsultasMedicas.Views
{
    public partial class VentanaRecepcionista : Window
    {
        public VentanaRecepcionista()
        {
            InitializeComponent();
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

        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }
    }
}
