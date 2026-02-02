using Modelo;

namespace RetaCantabria
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Usuario usuario=new Usuario();
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}