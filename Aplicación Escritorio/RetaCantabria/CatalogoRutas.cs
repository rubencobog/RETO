using Conexion;
using Modelo;
using ModeloDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetaCantabria
{
    public partial class CatalogoRutas : Form
    {

        private Usuario usuario;
        public CatalogoRutas(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.Load += CatalogoRutas_Load;
            gestorPermisos(usuario.rol);
        }

        private async void CatalogoRutas_Load(object sender, EventArgs e)
        {
            await CargarGrid();
        }

        public async Task CargarGrid()
        {

            var rutas = await ConexionAPI.CLIENTE.GetFromJsonAsync<List<Ruta>>(ConexionAPI.Conexion + "ruta");
            List<Ruta> rutasValidadas = new List<Ruta>();
            foreach (var ruta in rutas)
            {
                if (ruta.estadoRuta == true)
                {
                    rutasValidadas.Add(ruta);
                }
            }
            if (this.usuario.rol == TIPOUSUARIO.administrador)
            {
                dgvRutas.DataSource = rutas;

                foreach (DataGridViewRow row in dgvRutas.Rows)
                {
                    if ((bool)row.Cells["estadoRuta"].Value == false)
                    {
                        row.DefaultCellStyle.BackColor = Color.Coral;
                    }
                }
            }
            else
            {
                dgvRutas.DataSource = rutasValidadas;
            }

            dgvRutas.AutoGenerateColumns = true;
            dgvRutas.Columns.RemoveAt(0);
            dgvRutas.ReadOnly = true;
            dgvRutas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnResena_Click(object sender, EventArgs e)
        {
            if (dgvRutas.SelectedRows.Count > 0)
            {
                Ruta ruta = (Ruta)dgvRutas.SelectedRows[0].DataBoundItem;
                FormResena formResena = new FormResena(this.usuario, ruta, ConexionAPI.CLIENTE);
                formResena.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una ruta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnValorar_Click(object sender, EventArgs e)
        {
            if (dgvRutas.SelectedRows.Count > 0)
            {
                Ruta ruta = (Ruta)dgvRutas.SelectedRows[0].DataBoundItem;
                using (FormValoracion formV = new FormValoracion())
                {
                    if (formV.ShowDialog() == DialogResult.OK)
                    {
                        valoracionDTO valoracion = new valoracionDTO
                        {
                            idRuta = ruta.idRuta,
                            idUsuario = usuario.idUsuario,
                            dificultad = formV.dificultad,
                            belleza = formV.belleza,
                            interesCultural = formV.interes,
                            fecha = DateTime.Now

                        };
                        var response = await ConexionAPI.CLIENTE.PostAsJsonAsync(ConexionAPI.Conexion + "valoracion", valoracion);
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Valoración enviada con éxito", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al enviar la valoración" + response.ReasonPhrase, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una ruta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            CrearRuta crearRuta = new CrearRuta(usuario);
            crearRuta.Show();
        }

        //TODO Acabar de modificar los permisos asi como se agregen funciones
        private void gestorPermisos(TIPOUSUARIO permiso)
        {
            switch (permiso)
            {
                case TIPOUSUARIO.administrador:

                    break;
                case TIPOUSUARIO.diseñador:
                    btnValidar.Hide();
                    panelAdmin.Hide();
                    break;
                case TIPOUSUARIO.profesor:
                    btnValidar.Hide();
                    panelAdmin.Hide();
                    break;
                case TIPOUSUARIO.alumno:
                    btnValidar.Hide();
                    panelAdmin.Hide();
                    btnDescarga.Hide();
                    btnCrear.Hide();
                    break;
                default:
                    btnValidar.Hide();
                    panelAdmin.Hide();
                    btnDescarga.Hide();
                    btnCrear.Hide();
                    btnValorar.Hide();
                    btnResena.Hide();
                    break;
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            GestionUsuarios gestionUsuarios = new GestionUsuarios();
            gestionUsuarios.ShowDialog();
        }

        private async void btnValidar_Click(object sender, EventArgs e)
        {
            if (dgvRutas.SelectedRows.Count > 0)
            {
                Ruta ruta = (Ruta)dgvRutas.SelectedRows[0].DataBoundItem;
                if (ruta.estadoRuta)
                {
                    MessageBox.Show("La ruta ya está validada", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ruta.estadoRuta = true;
                    var response = ConexionAPI.CLIENTE.PutAsJsonAsync(ConexionAPI.Conexion + "ruta/" + ruta.idRuta, ruta).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Ruta validada con éxito", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarGrid();
                    }
                    else
                    {
                        MessageBox.Show("Error al validar la ruta: " + response.ReasonPhrase, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
