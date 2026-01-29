using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Modelo
{
    public class ImagenInteres
    {
        public int id { get; set; }

        public String url { get; set; }
        public String descripcion { get; set; }
        public PuntoInteres puntoInteres { get; set; }

    }
}
