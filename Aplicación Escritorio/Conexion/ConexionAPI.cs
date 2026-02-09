namespace Conexion
{
    public class ConexionAPI
    {
        public static string Conexion { get; } = "http://localhost:5050/api/";

        public static readonly HttpClient CLIENTE = new HttpClient();
            
    }
}
