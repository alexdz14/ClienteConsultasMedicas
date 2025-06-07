using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteConsultasMedicas.Models
{
    public class CitaResumen
    {
        public string id { get; set; } = "";
        public string paciente { get; set; } = "";
        public string medico { get; set; } = "";
        public DateTime fechaHora { get; set; }
        public string motivo { get; set; } = "";
        public string estado { get; set; } = "";
    }

}
