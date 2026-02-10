using Modelo;
using System.Text.Json.Serialization;

namespace ModeloDTO
{
    public class UsuarioDTO
    {
        public long idUsuario { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String email { get; set; }
        public String password { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TIPOUSUARIO? rol { get; set; }
    }
}
