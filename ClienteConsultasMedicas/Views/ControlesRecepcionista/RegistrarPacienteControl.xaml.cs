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
            var paciente = new Paciente
            {
                nombre = txtNombre.Text,
                email = txtEmail.Text,
                telefono = txtTelefono.Text
            };

            bool ok = await ApiService.RegistrarPacienteAsync(paciente);

            if (ok)
            {
                MessageBox.Show("Paciente registrado correctamente.");
                txtNombre.Text = "";
                txtEmail.Text = "";
                txtTelefono.Text = "";
            }
            else
            {
                MessageBox.Show("Error al registrar paciente.");
            }
        }
    }
}
