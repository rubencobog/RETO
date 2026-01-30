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
    public partial class GestionUsuarios : Form
    {
        private readonly HttpClient cliente;
        public GestionUsuarios(HttpClient cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            this.Load += GestionUsuarios_Load;
        }

        private void GestionUsuarios_Load1(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public async Task CargarUsuarios()
        {
            var usuarios = await cliente.GetFromJsonAsync<List<Usuario>>(ConexionAPI.Conexion + "usuario");
            dgvUsuarios.AutoGenerateColumns = true;
            dgvUsuarios.DataSource = usuarios;
            dgvUsuarios.Columns["idUsuario"].Visible = false;
            dgvUsuarios.Columns["password"].Visible = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.ReadOnly = true;
        }

        private async void GestionUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private async Task Eliminar_Click(object sender, EventArgs e)
        {
            if(dgvUsuarios.SelectedRows.Count > 0)
            {
                var usuarioSeleccionado = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;
                String url=ConexionAPI.Conexion + "usuario/"+usuarioSeleccionado.idUsuario;
                var resultado = await cliente.DeleteAsync(url);
                if (resultado.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario eliminado correctamente.");
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el usuario.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para eliminar.");
            }
    }
}
