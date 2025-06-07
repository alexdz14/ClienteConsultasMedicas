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

            bool conectado = await ApiService.HayConexionAsync();

            if (conectado)
            {
                var token = await ApiService.LoginAsync(usuario, contrasena);

                if (!string.IsNullOrEmpty(token))
                {
                    TokenHelper.SaveToken(token);

                    //Sincronización automática + mensaje
                    int sincronizados = await PacienteOfflineService.SincronizarPendientesAsync(true);
                    if (sincronizados > 0)
                    {
                        MessageBox.Show($"Se sincronizaron {sincronizados} pacientes correctamente.", "Sincronización automática");
                    }

                    string? rol = TokenHelper.GetRol();
                    AbrirVentanaPorRol(rol);
                }
                else
                {
                    MessageBox.Show("Credenciales inválidas o error en la conexión.");
                }
            }
            else
            {
                // Modo sin conexión
                if (TokenHelper.ExisteToken() && TokenHelper.GetRol() is string rolOffline)
                {
                    MessageBox.Show("Entrando en modo sin conexión con sesión previa.");
                    AbrirVentanaPorRol(rolOffline);
                }
                else
                {
                    MessageBox.Show("No hay conexión ni sesión previa disponible.");
                }
            }
        }

        private void AbrirVentanaPorRol(string rol)
        {
            if (rol == "medico")
            {
                new VentanaMedico().Show();
            }
            else if (rol == "recepcionista")
            {
                new VentanaRecepcionista().Show();
            }
            else
            {
                MessageBox.Show("Rol no reconocido.");
                return;
            }

            this.Close();
        }
    }
}
