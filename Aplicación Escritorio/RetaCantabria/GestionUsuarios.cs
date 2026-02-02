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

        public async Task CargarUsuarios()
        {
            var usuarios = await cliente.GetFromJsonAsync<List<Usuario>>(ConexionAPI.Conexion + "usuario");
            dgvUsuarios.AutoGenerateColumns = true;
            dgvUsuarios.DataSource = usuarios;
            dgvUsuarios.Columns["idUsuario"].Visible = false;
            dgvUsuarios.Columns["password"].Visible = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.ClearSelection();
        }

        private async void GestionUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            comboPermisos.DataSource = Enum.GetValues(typeof(TIPOUSUARIO));
            comboPermisos.Enabled = false;
        }

        private async void Eliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                var usuarioSeleccionado = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;
                String url = ConexionAPI.Conexion + "usuario/" + usuarioSeleccionado.idUsuario;
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

        private async void btnPermisos_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                var usuarioSeleccionado = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;
                usuarioSeleccionado.rol = (TIPOUSUARIO)comboPermisos.SelectedItem;
                HttpResponseMessage resultado = await cliente.PutAsJsonAsync(ConexionAPI.Conexion + "usuario/" + usuarioSeleccionado.idUsuario, usuarioSeleccionado);
                if (resultado.IsSuccessStatusCode)
                {
                    MessageBox.Show("Permisos actualizados correctamente.");
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("Error al actualizar los permisos.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para cambiar los permisos.");
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvUsuarios.CurrentRow!=null && !dgvUsuarios.CurrentRow.IsNewRow)
            {
                comboPermisos.Enabled = true;
                comboPermisos.SelectedItem = ((Usuario)dgvUsuarios.CurrentRow.DataBoundItem).rol;
            }
            else
            {
                comboPermisos.Enabled = false;
            }
        }
    }
}
