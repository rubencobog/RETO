using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public TIPOUSUARIO rol { get; set; }
        public List<Valoracion> valoraciones { get; set; }
        public List<Resena> resenas { get; set; }


    }
}
