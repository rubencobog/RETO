using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDTO
{
    public class CalendarioDTO
    {
        public String fecha { get; set; }
        public String detalles { get; set; }
        public String recomendaciones { get; set; }
        public long idRuta { get; set; }
        public long idUsuario { get; set; }

    }
}
