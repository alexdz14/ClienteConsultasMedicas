using ClienteConsultasMedicas.Models;
using ClienteConsultasMedicas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace ClienteConsultasMedicas.Views.ControlesRecepcionista
{
    public partial class DashboardControl : UserControl
    {
        public DashboardControl()
        {
            InitializeComponent();
            CargarResumen();
        }

        private async void CargarResumen()
        {
            var pacientes = await ApiService.ObtenerTodosPacientesAsync();
            var citas = await ApiService.ObtenerTodasCitasAsync();

            int totalPacientes = pacientes.Count;
            int citasActivas = citas.Count(c => c.estado != "cancelada");
            int citasCanceladas = citas.Count(c => c.estado == "cancelada");
            int citasHoy = citas.Count(c =>
                c.fechaHora.Date == DateTime.Today &&
                c.estado != "cancelada");

            txtPacientes.Text = totalPacientes.ToString();
            txtActivas.Text = citasActivas.ToString();
            txtCanceladas.Text = citasCanceladas.ToString();
            txtHoy.Text = citasHoy.ToString();
        }
    }
}
