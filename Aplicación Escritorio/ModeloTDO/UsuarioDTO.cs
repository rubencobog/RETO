using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModeloDTO
{
    public class UsuarioDTO
    {
        public long idUsuario { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String email { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TIPOUSUARIO? rol { get; set; }
    }
}
