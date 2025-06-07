using System;
using System.Windows;
using ClienteConsultasMedicas.Services;
using ClienteConsultasMedicas.Utils;

namespace ClienteConsultasMedicas.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnRegistro_Click(object sender, RoutedEventArgs e)
        {
            var registro = new VentanaRegistro();
            registro.ShowDialog();
        }

        private void CamposLogin_Cambiados(object sender, RoutedEventArgs e)
        {
            bool camposLlenos =
                !string.IsNullOrWhiteSpace(txtUsuario.Text) &&
                !string.IsNullOrWhiteSpace(txtContrasena.Password);

            btnLogin.IsEnabled = camposLlenos;
        }


        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            var usuario = txtUsuario.Text;
            var contrasena = txtContrasena.Password;

            var token = await ApiService.LoginAsync(usuario, contrasena);

            if (!string.IsNullOrEmpty(token))
            {
                TokenHelper.SaveToken(token);

                //Sincronización offline
                bool conectado = await ApiService.HayConexionAsync();
                if (conectado)
                {
                    await PacienteOfflineService.SincronizarPendientesAsync();
                }

                string? rol = TokenHelper.GetRol();

                if (rol == "medico")
                {
                    var medicoWindow = new VentanaMedico();
                    medicoWindow.Show();
                }
                else if (rol == "recepcionista")
                {
                    var recepcionistaWindow = new VentanaRecepcionista();
                    recepcionistaWindow.Show();
                }
                else
                {
                    MessageBox.Show("Rol no reconocido.");
                    return;
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciales inválidas o error en la conexión.");
            }
        }

    }
}
