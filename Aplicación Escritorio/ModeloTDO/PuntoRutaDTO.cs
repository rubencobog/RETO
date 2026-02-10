using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDTO
{
    public class PuntoRutaDTO
    {
        public int? idPuntoRuta { get; set; }
        public double? longitud { get; set; }
        public double? latitud { get; set; }
        public int? elevacion { get; set; }
        public DateTime? timestamp { get; set; }
    }
}
