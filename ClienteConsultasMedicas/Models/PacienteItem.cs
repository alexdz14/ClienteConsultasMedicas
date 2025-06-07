using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteConsultasMedicas.Models
{
    public class PacienteItem
    {
        public string id { get; set; } = "";
        public string nombre { get; set; } = "";

        public override string ToString()
        {
            return nombre;
        }
    }
}
