using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Valoracion
    {
        public int id { get; set; }
        public int dificultad { get; set; }
        public int belleza { get; set; }
        public int interesCultural { get; set; }
        public DateTime fecha { get; set; }
        public Usuario usuario { get; set; }
        public Ruta ruta { get; set; }

    }
}
