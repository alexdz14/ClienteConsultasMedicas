using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteConsultasMedicas.Models
{
    public class CitaNueva
    {
        public string pacienteId { get; set; } = "";
        public string medicoId { get; set; } = "";
        public string fecha { get; set; } = ""; // formato: "YYYY-MM-DD"
        public string hora { get; set; } = "";  // formato: "HH:MM"
        public string motivo { get; set; } = "";
    }
}
