using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDTO
{
    public class ValoracionDevueltaDTO
    {
        public int idValoracion { get; set; }
        public int dificultad { get; set; }
        public int belleza { get; set; }
        public int interesCultural { get; set; }
        public String nomUsuario { get; set; }
        public String nomRuta { get; set; }

        public DateTimeOffset fecha { get; set; }

    }
}
