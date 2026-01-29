using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Modelo
{
    public class PuntoInteres
    {
        public long id;

        public String nombre { get; set; }
        public TIPOPI tipo { get; set; }
        public String caracteristicasEspeciales { get; set; }

        public List<ImagenInteres> imagenes { get; set; }
        public PuntoRuta puntoRuta { get; set; }

    }
}
