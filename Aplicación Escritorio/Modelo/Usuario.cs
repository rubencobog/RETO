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
        public String nombre;
        public String apellido;
        public String email;
        public String password;
        public TIPOUSUARIO rol;
        public List<Valoracion> valoraciones;
        public List<Resena> resenas;


    }
}
