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
        }
    }
