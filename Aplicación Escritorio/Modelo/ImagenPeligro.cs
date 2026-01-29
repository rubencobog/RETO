using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    internal class ImagenPeligro
    {
        public int id { get; set; }
        public String url { get; set; }
        public String descripcion { get; set; }
        public PuntoPeligro puntoPeligro { get; set; }

    }
}
