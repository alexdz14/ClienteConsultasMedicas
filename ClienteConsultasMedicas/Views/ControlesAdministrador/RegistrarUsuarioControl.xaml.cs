using ClienteConsultasMedicas.Services;
using System.Windows;
using System.Windows.Controls;

namespace ClienteConsultasMedicas.Views.ControlesAdministrador
{
    public partial class RegistrarUsuarioControl : UserControl
    {
        public RegistrarUsuarioControl()
        {
            InitializeComponent();
        }

        private async void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContrasena.Password.Trim();
            string rol = (cmbRol.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(contrasena) ||
                string.IsNullOrWhiteSpace(rol))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            bool ok = await ApiService.RegistrarUsuarioAsync(nombre, correo, contrasena, rol);

            if (ok)
            {
                MessageBox.Show("Usuario registrado correctamente.");
                txtNombre.Text = "";
                txtCorreo.Text = "";
                txtContrasena.Password = "";
                cmbRol.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Error al registrar el usuario.");
            }
        }
    }
}
