using Modelo;
using System.Text.Json.Serialization;

namespace ModeloDTO
{
    public class RutaSimplificadaDTO
    {
        public long idRuta { get; set; }
        public long idUsuario { get; set; }
        public string nombre { get; set; }

        public double distancia { get; set; }
        public TimeSpan duracion { get; set; }
        public string temporadas { get; set; }
        public string recomendacionesEquipo { get; set; }
        public double? mediaEstrellas { get; set; }
        public string zonaGeografica { get; set; }
        public bool estadoRuta { get; set; }
        public bool accesible { get; set; }
        public bool familiar { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CLASIFICACION clasificacion { get; set; }

        public RutaSimplificadaDTO(RutaDTO rutaDTO)
        {
            this.idRuta= rutaDTO.idRuta;
            this.idUsuario = rutaDTO.idUsuario;
            this.nombre = rutaDTO.nombre;
            this.distancia = rutaDTO.distancia;
            this.duracion = rutaDTO.duracion;
            this.temporadas = rutaDTO.temporadas;
            this.recomendacionesEquipo = rutaDTO.recomendacionesEquipo;
            this.mediaEstrellas = rutaDTO.mediaEstrellas;
            this.zonaGeografica = rutaDTO.zonaGeografica;
            this.estadoRuta = rutaDTO.estadoRuta;
            this.accesible = rutaDTO.accesible;
            this.familiar = rutaDTO.familiar;
            this.clasificacion = rutaDTO.clasificacion;
        }
    }
}
