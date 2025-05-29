using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using ClienteConsultasMedicas.Services;

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
                MessageBox.Show("Login exitoso");

                // Aquí puedes guardar el token y abrir la ventana principal según rol
                // Ejemplo: abrir MainWindow
                var main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciales inválidas o error en la conexión.");
            }
        }

    }
}

