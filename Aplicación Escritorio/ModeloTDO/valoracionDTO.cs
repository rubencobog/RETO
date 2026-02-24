using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDTO
{
    public class valoracionDTO
    {
            public long idRuta { get; set; }
            public long idUsuario { get; set; }
            public int dificultad { get; set; }
        public int belleza { get; set; }
        public int interesCultural { get; set; }
        public DateTimeOffset fecha { get; set; }
        }
    }
