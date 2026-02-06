using Conexion;
using Modelo;
using System.Net.Http.Json;

namespace RetaCantabria
{
    public partial class Login : Form
    {
        HttpClient cliente = ConexionAPI.CLIENTE;
        private Usuario USUARIO;
        public Login()
        {

            InitializeComponent();
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            if (!txtEmail.Text.Equals(String.Empty) && !txtPassword.Text.Equals(String.Empty))
            {

               await loginAsync(txtEmail.Text, txtPassword.Text);

            }
            else
            {
                MessageBox.Show("Debe rellenar ambos campos","ATENCION",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        private async Task loginAsync(string email, string password)
        {
            try { 
            HttpResponseMessage respuesta = await cliente.GetAsync(ConexionAPI.Conexion + $"usuario/login?email={email}&password={password}");

            if (!respuesta.IsSuccessStatusCode)
            {
                MessageBox.Show("Usuario no válido o error en la conexión.");
                return;
            }

            Usuario usuario = await respuesta.Content.ReadFromJsonAsync<Usuario>();

            if (usuario == null)
            {
                MessageBox.Show("Usuario no válido");
                return;
            }

                USUARIO = usuario;
            MessageBox.Show(usuario.nombre, usuario.idUsuario.ToString());

            this.Hide();
            CatalogoRutas catalogo = new CatalogoRutas(usuario);
            catalogo.ShowDialog();
            this.Close();
        }
    catch (Exception ex)
    {
        MessageBox.Show("Ocurrió un error: " + ex.Message);
    }

}

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            CrearUsuario crearUsuario = new CrearUsuario();
            crearUsuario.Show();
        }

        private void labelEntrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Usuario usuario = new Usuario();
            CatalogoRutas catalogo = new CatalogoRutas(usuario);
            catalogo.ShowDialog();
        }
    }
}
