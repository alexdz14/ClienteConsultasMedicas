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
        }

        private async void GuardarConsulta_Click(object sender, RoutedEventArgs e)
        {
            var consulta = new Consulta
            {
                pacienteId = txtPacienteId.Text,
                sintomas = txtSintomas.Text,
                diagnostico = txtDiagnostico.Text,
                tratamiento = txtTratamiento.Text
            };

            bool ok = await ApiService.RegistrarConsultaAsync(consulta);

            if (ok)
            {
                MessageBox.Show("Consulta registrada correctamente.");
                txtPacienteId.Text = "";
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
