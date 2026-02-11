using Modelo;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace ModeloDTO
{
    public class RutaDTO
    {
        public long idRuta { get; set; }
        public long idUsuario { get; set; }
        public string nombre { get; set; }
        public string nombreInicioruta { get; set; }
        public string nombreFinalruta { get; set; }

        public double latitudInicial { get; set; }
        public double latitudFinal { get; set; }
        public double longitudInicial { get; set; }
        public double longitudFinal { get; set; }
        public double distancia { get; set; }

        public TimeSpan duracion { get; set; }
        public int desnivelPositivo { get; set; }
        public int desnivelNegativo { get; set; }

        public int desnivelAcumulado { get; set; }
        public double altitudMax { get; set; }
        public double altitudMin { get; set; }
        public byte nivelEsfuerzo { get; set; }
        public byte nivelRiesgo { get; set; }
        public byte tipoTerreno { get; set; }
        public byte indicaciones{ get; set; }
        public string temporadas { get; set; }
        public string recomendacionesEquipo { get; set; }
        public double? mediaEstrellas { get; set; }
        public string zonaGeografica { get; set; }
        public bool estadoRuta { get; set; }
        public bool accesible { get; set; }
        public bool familiar { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CLASIFICACION clasificacion { get; set; }
    }
    }
