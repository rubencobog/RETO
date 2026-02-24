using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Modelo
{
    public class Calendario
    {
        public int id;

        public DateOnly fecha { get; set; }
        public String detalles { get; set; }
        public String recomendaciones { get; set; }
        public Ruta rutasIdruta { get; set; }
        public Usuario usuarioIdusuario { get; set; }


    }
}
