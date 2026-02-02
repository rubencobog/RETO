namespace Conexion
{
    public class ConexionAPI
    {
        public static string Conexion { get; } = "http://192.168.56.1:5050/api/";

        public static readonly HttpClient CLIENTE = new HttpClient();
            
    }
}
