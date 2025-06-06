using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteConsultasMedicas.Models
{
    public class Cita
    {
        public string paciente { get; set; } = "";
        public string fecha { get; set; } = "";
        public string hora { get; set; } = "";
        public string motivo { get; set; } = "";
    }
}

