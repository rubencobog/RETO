using Conexion;
using Modelo;
using ModeloDTO;
using System.Net.Http.Json;

namespace RetaCantabria
{
    public partial class CrearUsuario : Form
    {
        private readonly HttpClient cliente = ConexionAPI.CLIENTE;
        private UsuarioDTO usuario;
        private readonly bool esNuevo;
        public CrearUsuario()
        {
            InitializeComponent();
            esNuevo = true;
        }
        public CrearUsuario(UsuarioDTO usuario)
        {
            InitializeComponent();
            this.Load += CrearUsuario_Load;
            this.usuario = usuario;
            esNuevo = false;

        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            String nombre = txtNombre.Text;
            String apellido = txtApellido.Text;
            String email = txtEmail.Text;
            String password = txtPassword.Text;
            if (!String.IsNullOrWhiteSpace(nombre) && !String.IsNullOrWhiteSpace(apellido) && !String.IsNullOrWhiteSpace(email) && !String.IsNullOrWhiteSpace(password))
            {
                if (esNuevo)
                {
                    Usuario usuarioCrear = new Usuario
                    {
                        nombre = nombre,
                        apellido = apellido,
                        email = email,
                        password = password,
                        rol = TIPOUSUARIO.alumno,
                        valoraciones = new List<Valoracion>(),
                        resenas = new List<Resena>(),
                        calendarios=new List<Calendario>()
                    };
                    try
                    {
                        HttpResponseMessage response = await cliente.PostAsJsonAsync(ConexionAPI.Conexion + "usuario", usuarioCrear);
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Usuario creado con éxito.");
                            usuario= await response.Content.ReadFromJsonAsync<UsuarioDTO>();
                            CatalogoRutas catalog = new CatalogoRutas(usuario);
                            catalog.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error al crear el usuario: " + response.ReasonPhrase);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al conectar con el servidor: " + ex.Message);
                    }
            }
            else
            {
                usuario.nombre = nombre;
                usuario.apellido = apellido;
                usuario.email = email;
                usuario.password = password;
                try
                {
                    HttpResponseMessage response = await cliente.PutAsJsonAsync(ConexionAPI.Conexion + "usuario/" + usuario.idUsuario, usuario);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Usuario actualizado con éxito.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el usuario: " + response.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con el servidor: " + ex.Message);
                }
            }
            }
            else
            {
                MessageBox.Show("Por favor, rellene todos los campos.");
            }
        }

        private void CrearUsuario_Load(object sender, EventArgs e)
        {
            if (!esNuevo)
            {
                txtNombre.Text = usuario.nombre;
                txtApellido.Text = usuario.apellido;
                txtEmail.Text = usuario.email;
                btnRegistrar.Text = "Actualizar";
            }
            else
            {
                btnRegistrar.Text = "Registrar";
            }
        }
    }
}
