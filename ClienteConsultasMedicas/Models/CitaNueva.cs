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
        public DateTime fechaHora { get; set; }
        public string motivo { get; set; } = "";
    }

}
