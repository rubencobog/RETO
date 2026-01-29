using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    internal class Resena
    {
        public int idResena { get; set; }
        public String resena { get; set; }
        public DateOnly fecha { get; set; }
        public Usuario usuario { get; set; }
        public Ruta ruta { get; set; }
    }
}
