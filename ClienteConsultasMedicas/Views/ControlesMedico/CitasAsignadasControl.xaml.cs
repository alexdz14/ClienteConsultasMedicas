using ClienteConsultasMedicas.Models;
using ClienteConsultasMedicas.Services;
using ClienteConsultasMedicas.Utils;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ClienteConsultasMedicas.Views.ControlesMedico
{
    public partial class CitasAsignadasControl : UserControl
    {
        public CitasAsignadasControl()
        {
            InitializeComponent();
            CargarCitas();
        }

        private async void CargarCitas()
        {
            string? medicoId = TokenHelper.GetId(); // Necesitamos extraerlo del JWT
            if (medicoId == null) return;

            List<Cita> citas = await ApiService.GetCitasPorMedicoAsync(medicoId);
            dgCitas.ItemsSource = citas;
        }
    }
}
