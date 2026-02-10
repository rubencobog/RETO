using Modelo;
using System.Text.Json.Serialization;

namespace ModeloDTO
{
    public class RutaDTO
    {
            public int IdRuta { get; set; }
            public string Nombre { get; set; }
            public string NombreInicioruta { get; set; }
            public string NombreFinalruta { get; set; }
            public double Distancia { get; set; }
            public TimeSpan Duracion { get; set; }
            public double? MediaEstrellas { get; set; }
            public string ZonaGeografica { get; set; }
        public bool estadoRuta { get; set; }
        public bool accesible { get; set; }
        public bool familiar { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CLASIFICACION clasificacion { get; set; }
    }
    }
