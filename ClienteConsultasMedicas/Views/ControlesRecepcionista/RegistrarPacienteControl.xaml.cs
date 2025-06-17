using ClienteConsultasMedicas.Models;
using ClienteConsultasMedicas.Services;
using System.Windows;
using System.Windows.Controls;

namespace ClienteConsultasMedicas.Views.ControlesRecepcionista
{
    public partial class RegistrarPacienteControl : UserControl
    {
        public RegistrarPacienteControl()
        {
            InitializeComponent();
        }

        private async void RegistrarPaciente_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            if (!EsEmailValido(txtEmail.Text))
            {
                MessageBox.Show("El email no tiene un formato válido.");
                return;
            }

            bool enLinea = await ApiService.HayConexionAsync();

            if (enLinea)
            {
                var usuarioPaciente = new
                {
                    nombre = txtNombre.Text,
                    correo = txtEmail.Text,
                    contrasena = txtPassword.Password
                };

                bool ok = await ApiService.RegistrarUsuarioPacienteAsync(usuarioPaciente);

                if (ok)
                {
                    var paciente = new Paciente
                    {
                        nombre = txtNombre.Text,
                        email = txtEmail.Text,
                        telefono = txtTelefono.Text
                    };

                    bool registrado = await ApiService.RegistrarPacienteAsync(paciente);

                    if (registrado)
                        MessageBox.Show("Paciente registrado correctamente con acceso y disponible para agendar citas.");
                    else
                        MessageBox.Show("El usuario fue creado, pero no se pudo registrar como paciente clínico.");
                }
                else
                {
                    MessageBox.Show("Error al registrar paciente.");
                }
            }
            else
            {
                MessageBox.Show("Este tipo de registro requiere conexión.");
            }

            txtNombre.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtPassword.Password = "";
        }

        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}
