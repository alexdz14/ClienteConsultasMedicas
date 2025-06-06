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

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            var usuario = txtUsuario.Text;
            var contrasena = txtContrasena.Password;

            var token = await ApiService.LoginAsync(usuario, contrasena);

            if (!string.IsNullOrEmpty(token))
            {
                TokenHelper.SaveToken(token);

                string? rol = TokenHelper.GetRol();
                MessageBox.Show($"Login exitoso. Rol: {rol}");

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
