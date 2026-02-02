using Conexion;
using Modelo;
using System.Net.Http.Json;

namespace RetaCantabria
{
    public partial class Login : Form
    {
        HttpClient cliente= ConexionAPI.CLIENTE;
        public Login()
        {

            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (!txtEmail.Text.Equals(String.Empty) || !txtPassword.Text.Equals(String.Empty))
            {

                var usuario = getLoginAsync(txtEmail.Text, txtPassword.Text);

                //MessageBox.Show(usuario.nombre)
            }
        }
        private async Task getLoginAsync(string email, string password)
        {
            var queryParams = new Dictionary<string, string>
            {
                ["email"] = txtEmail.Text,
                ["password"] = txtPassword.Text,
            };

            var rutas = await ConexionAPI.CLIENTE.GetAsync(ConexionAPI.Conexion + "usuario/login?email=" + email + "&password=" + password);
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            CrearUsuario crearUsuario = new CrearUsuario(cliente);
            crearUsuario.Show();
        }
    }
}
