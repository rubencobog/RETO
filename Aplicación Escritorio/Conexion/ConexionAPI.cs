namespace Conexion
{
    public class ConexionAPI
    {
        public static string Conexion { get; } = "http://10.0.22.11:5050/api/";

        public static readonly HttpClient CLIENTE = new HttpClient();
            
    }
}
