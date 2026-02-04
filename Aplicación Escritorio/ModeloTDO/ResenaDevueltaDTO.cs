using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDTO
{
    public class ResenaDevueltaDTO
    {
        public int idResena { get; set; }
        public String resena { get; set; }
        public DateOnly fecha { get; set; }
        public String nomUsuario { get; set; }
        public String nomRuta { get; set; }
    }
}
