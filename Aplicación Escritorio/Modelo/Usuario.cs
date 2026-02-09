using System.Text.Json.Serialization;

namespace Modelo
{
    public class Usuario
    {
        public long idUsuario { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String email { get; set; }
        public String password { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TIPOUSUARIO? rol { get; set; }
        public List<Valoracion> valoraciones { get; set; }
        public List<Resena> resenas { get; set; }
        public List<Calendario>calendarios { get; set; }
    }
}
