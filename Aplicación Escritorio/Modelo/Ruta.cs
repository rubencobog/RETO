using System;
using System.IO;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Modelo
{
    public class Ruta
    {
        public int idRuta { get; set; }
        public String nombre { get; set; }
        public String nombreInicioruta { get; set; }

        public String nombreFinalruta { get; set; }

        public Double latitudInicial { get; set; }

        public Double latitudFinal { get; set; }

        public Double longitudInicial { get; set; }

        public Double longitudFinal { get; set; }

        public Double distancia { get; set; }

        public TimeOnly duracion { get; set; }

        public int desnivelPositivo { get; set; }


        public int desnivelNegativo { get; set; }

        public int desnivelAcumulado { get; set; }

        public Double altitudMax { get; set; }

        public Double altitudMin { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CLASIFICACION clasificacion { get; set; }

        public Byte nivelEsfuerzo { get; set; }

        public Byte nivelRiesgo { get; set; }

        public Boolean estadoRuta { get; set; }

        public Byte tipoTerreno { get; set; }

        public Byte indicaciones { get; set; }

        public String temporadas { get; set; }

        public Boolean accesibilidad { get; set; }

        public Boolean rutaFamiliar { get; set; }


        public String archivoGPX { get; set; }

        public String recomendacionesEquipo { get; set; }

        public String zonaGeografica { get; set; }

        public Double mediaEstrellas { get; set; }

        public Usuario usuarioIdusuario { get; set; }
        public List<PuntoRuta> puntos { get; set; }

        public List<Valoracion> valoraciones { get; set; }

        public List<Resena> resenas { get; set; }


    }
}
