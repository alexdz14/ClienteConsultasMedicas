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
                string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            if (!EsEmailValido(txtEmail.Text))
            {
                MessageBox.Show("El email no tiene un formato válido.");
                return;
            }

            var paciente = new Paciente
            {
                nombre = txtNombre.Text,
                email = txtEmail.Text,
                telefono = txtTelefono.Text
            };

            bool enLinea = await ApiService.HayConexionAsync();

            if (enLinea)
            {
                bool ok = await ApiService.RegistrarPacienteAsync(paciente);

                if (ok)
                {
                    MessageBox.Show("Paciente registrado correctamente (en línea).");
                }
                else
                {
                    MessageBox.Show("Error al registrar paciente en línea.");
                }
            }
            else
            {
                paciente.sincronizado = false;
                PacienteOfflineService.GuardarPaciente(paciente);
                MessageBox.Show("Paciente guardado localmente (sin conexión).");
            }

            txtNombre.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
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
