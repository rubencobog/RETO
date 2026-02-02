using Conexion;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetaCantabria
{
    public partial class CrearUsuario : Form
    {
        private readonly HttpClient cliente;
        public CrearUsuario(HttpClient cliente)
        {
            this.cliente = cliente;
            InitializeComponent();
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            String nombre= txtNombre.Text;
            String apellido= txtApellido.Text;
            String email= txtEmail.Text;
            String password= txtPassword.Text;
            if (!String.IsNullOrWhiteSpace(nombre) && !String.IsNullOrWhiteSpace(apellido) && !String.IsNullOrWhiteSpace(email) && !String.IsNullOrWhiteSpace(password))
            {
                Usuario usuario=new Usuario
                {
                    nombre = nombre,
                    apellido = apellido,
                    email = email,
                    password = password,
                    rol = TIPOUSUARIO.alumno,
                    valoraciones = new List<Valoracion>(),
                    resenas = new List<Resena>()
                };
                try
                {
                    HttpResponseMessage response = await cliente.PostAsJsonAsync(ConexionAPI.Conexion+"usuario", usuario);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Usuario creado con éxito.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el usuario: " + response.ReasonPhrase);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al conectar con el servidor: " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Por favor, rellene todos los campos.");
            }
        }
    }
}
