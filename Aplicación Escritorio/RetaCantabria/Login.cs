using Conexion;
using Modelo;
using ModeloDTO;
using RetaCantabria.Properties;
using System.Net.Http.Json;

namespace RetaCantabria
{
    public partial class Login : Form
    {
        HttpClient cliente = ConexionAPI.CLIENTE;
        private UsuarioDTO USUARIO;
        public Login()
        {

            InitializeComponent();
            pictureLogo.Image=Properties.Resources.itinere_logo;
            btnIniciar.BackColor = Color.FromArgb(74, 82, 90);
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
                MessageBox.Show("Usuario no valido o error en la conexion.");
                return;
            }

            UsuarioDTO usuario = await respuesta.Content.ReadFromJsonAsync<UsuarioDTO>();

            if (usuario == null)
            {
                MessageBox.Show("Usuario no valido");
                return;
            }

            USUARIO = usuario;
            CatalogoRutas catalogo = new CatalogoRutas(usuario);
            catalogo.ShowDialog();
            this.Close();
        }
    catch (Exception ex)
    {
        MessageBox.Show("Ocurrio un error: " + ex.Message);
    }

}

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            CrearUsuario crearUsuario = new CrearUsuario();
            crearUsuario.Show();
        }

        private void labelEntrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UsuarioDTO usuario = new UsuarioDTO();
            CatalogoRutas catalogo = new CatalogoRutas(usuario);
            catalogo.ShowDialog();
        }
    }
}
