using ClienteConsultasMedicas.Models;
using ClienteConsultasMedicas.Services;
using System.Windows;
using System.Windows.Controls;

namespace ClienteConsultasMedicas.Views.ControlesMedico
{
    public partial class RegistrarConsultaControl : UserControl
    {
        public RegistrarConsultaControl()
        {
            InitializeComponent();
            CargarPacientes();
        }

        private async void CargarPacientes()
        {
            var pacientes = await ApiService.ObtenerPacientesAsync();
            cmbPacientes.ItemsSource = pacientes;
        }

        private async void GuardarConsulta_Click(object sender, RoutedEventArgs e)
        {
            if (cmbPacientes.SelectedItem is not PacienteItem pacienteSeleccionado)
            {
                MessageBox.Show("Selecciona un paciente.");
                return;
            }

            var consulta = new Consulta
            {
                pacienteId = pacienteSeleccionado.id,
                sintomas = txtSintomas.Text,
                diagnostico = txtDiagnostico.Text,
                tratamiento = txtTratamiento.Text,
                FechaHora = DateTime.Now
            };


            bool ok = await ApiService.RegistrarConsultaAsync(consulta);

            if (ok)
            {
                MessageBox.Show("Consulta registrada correctamente.");
                cmbPacientes.SelectedIndex = -1;
                txtSintomas.Text = "";
                txtDiagnostico.Text = "";
                txtTratamiento.Text = "";
            }
            else
            {
                MessageBox.Show("Error al registrar consulta.");
            }
        }
    }
}