using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteConsultasMedicas.Models
{
    public class ConsultaHistorial
    {
        public string fecha { get; set; } = "";
        public string sintomas { get; set; } = "";
        public string diagnostico { get; set; } = "";
        public string tratamiento { get; set; } = "";
    }
}
