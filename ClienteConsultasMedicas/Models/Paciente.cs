using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteConsultasMedicas.Models
{
    public class Paciente
    {
        public string id { get; set; } = "";
        public string nombre { get; set; } = "";
        public string email { get; set; } = "";
        public string telefono { get; set; } = "";
        public bool sincronizado { get; set; } = true;

    }
}
