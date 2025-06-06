using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClienteConsultasMedicas.Models;
using ClienteConsultasMedicas.Services;
using System.Windows;
using System.Windows.Controls;

namespace ClienteConsultasMedicas.Views.ControlesRecepcionista
{
    public partial class RegistrarCitaControl : UserControl
    {
        public RegistrarCitaControl()
        {
            InitializeComponent();
        }

        private async void RegistrarCita_Click(object sender, RoutedEventArgs e)
        {
            var cita = new CitaNueva
            {
                pacienteId = txtPacienteId.Text,
                medicoId = txtMedicoId.Text,
                fecha = txtFecha.Text,
                hora = txtHora.Text,
                motivo = txtMotivo.Text
            };

            bool ok = await ApiService.RegistrarCitaAsync(cita);

            if (ok)
            {
                MessageBox.Show("Cita registrada exitosamente.");
                txtPacienteId.Text = "";
                txtMedicoId.Text = "";
                txtFecha.Text = "";
                txtHora.Text = "";
                txtMotivo.Text = "";
            }
            else
            {
                MessageBox.Show("Error al registrar cita.");
            }
        }
    }
}
