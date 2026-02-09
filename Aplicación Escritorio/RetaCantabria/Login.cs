using Conexion;
using Modelo;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;

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

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (!txtEmail.Text.Equals(String.Empty) || !txtPassword.Text.Equals(String.Empty))
            {

                loginAsync(txtEmail.Text, txtPassword.Text);

            }
        }
        private async Task loginAsync(string email, string password)
        {
            HttpResponseMessage respuesta = await ConexionAPI.CLIENTE.GetAsync(ConexionAPI.Conexion + "usuario/login?email=" + email + "&password=" + password);

            USUARIO = await respuesta.Content.ReadFromJsonAsync<Usuario>();

            if (USUARIO == null)
            {
                MessageBox.Show("Usuario no valido");
            }
            else
            {

                this.Hide();
                CatalogoRutas catalogo = new CatalogoRutas(USUARIO);
                catalogo.ShowDialog();


                this.Close();


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
