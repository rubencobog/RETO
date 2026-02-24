using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Modelo
{
    public class PuntoPeligro
    {
        public long id { get; set; }
        public Double kilometro { get; set; }

        public Byte gravedad { get; set; }

        public String justificacion { get; set; }

        public List<ImagenPeligro> imagenes { get; set; }
        [JsonIgnore]
        public PuntoRuta puntoRuta { get; set; }

    }
}
