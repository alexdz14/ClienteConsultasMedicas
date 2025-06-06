using ClienteConsultasMedicas.Models;
using ClienteConsultasMedicas.Services;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ClienteConsultasMedicas.Views.ControlesRecepcionista
{
    public partial class VerPacientesControl : UserControl
    {
        private List<Paciente> pacientes = new();
        private Paciente? pacienteSeleccionado = null;

        public VerPacientesControl()
        {
            InitializeComponent();
            CargarPacientes();
        }

        private async void CargarPacientes()
        {
            pacientes = await ApiService.ObtenerTodosPacientesAsync();
            dgPacientes.ItemsSource = pacientes;
        }

        private void dgPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pacienteSeleccionado = dgPacientes.SelectedItem as Paciente;
            if (pacienteSeleccionado != null)
            {
                txtNombre.Text = pacienteSeleccionado.nombre;
                txtEmail.Text = pacienteSeleccionado.email;
                txtTelefono.Text = pacienteSeleccionado.telefono;
            }
        }

        private async void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (pacienteSeleccionado == null) return;

            pacienteSeleccionado.nombre = txtNombre.Text;
            pacienteSeleccionado.email = txtEmail.Text;
            pacienteSeleccionado.telefono = txtTelefono.Text;

            bool ok = await ApiService.ActualizarPacienteAsync(pacienteSeleccionado);
            if (ok)
            {
                MessageBox.Show("Paciente actualizado.");
                CargarPacientes();
            }
            else
            {
                MessageBox.Show("Error al actualizar.");
            }
        }

        private async void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (pacienteSeleccionado == null) return;

            bool ok = await ApiService.EliminarPacienteAsync(pacienteSeleccionado.id);
            if (ok)
            {
                MessageBox.Show("Paciente eliminado.");
                CargarPacientes();
            }
            else
            {
                MessageBox.Show("Error al eliminar.");
            }
        }
    }
}
