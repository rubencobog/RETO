using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDTO
{
    public class ResenaDTO
    {
        public long idRuta { get; set; }
        public long idUsuario { get; set; }
        public string resena { get; set; }
        public DateOnly fecha { get; set;}
    }
}
