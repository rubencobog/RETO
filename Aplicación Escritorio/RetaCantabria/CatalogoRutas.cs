using Conexion;
using Modelo;
using ModeloDTO;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Windows.Forms.Design.AxImporter;

namespace RetaCantabria
{
    public partial class CatalogoRutas : Form
    {

        private UsuarioDTO usuario;
        public CatalogoRutas(UsuarioDTO usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.Load += CatalogoRutas_Load;
            gestorPermisos(usuario.rol);
        }

        private async void CatalogoRutas_Load(object sender, EventArgs e)
        {
            await CargarGrid();
            panelAdmin.Visible = false;
        }

        public async Task CargarGrid()
        {
            var rutas = await ConexionAPI.CLIENTE.GetFromJsonAsync<List<RutaDTO>>(ConexionAPI.Conexion + "ruta");

            List<RutaDTO> rutasValidadas = new List<RutaDTO>();
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
                RutaDTO ruta = (RutaDTO)dgvRutas.SelectedRows[0].DataBoundItem;
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
                RutaDTO ruta = (RutaDTO)dgvRutas.SelectedRows[0].DataBoundItem;
                using (FormValoracion formV = new FormValoracion())
                {
                    if (formV.ShowDialog() == DialogResult.OK)
                    {
                        valoracionDTO valoracion = new valoracionDTO
                        {
                            idRuta = ruta.IdRuta,
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

        private async void btnCrear_Click(object sender, EventArgs e)
        {
            using (CrearRuta crearRuta = new CrearRuta(usuario))
            {
                if (crearRuta.ShowDialog() == DialogResult.OK)
                {
                    await CargarGrid();
                }
            }

        }
        private void gestorPermisos(TIPOUSUARIO? permiso)
        {
            switch (permiso)
            {
                case TIPOUSUARIO.administrador:

                    break;
                case TIPOUSUARIO.diseñador:
                    btnMenuAdmin.Hide();
                    btnCalendario.Hide();
                    btnValidar.Hide();
                    panelAdmin.Hide();
                    break;
                case TIPOUSUARIO.profesor:
                    btnMenuAdmin.Hide();
                    btnValidar.Hide();
                    panelAdmin.Hide();
                    break;
                case TIPOUSUARIO.alumno:
                    btnMenuAdmin.Hide();
                    btnCalendario.Hide();
                    btnValidar.Hide();
                    panelAdmin.Hide();
                    btnDescarga.Hide();
                    btnCrear.Hide();
                    break;
                default:
                    btnMenuAdmin.Hide();
                    btnCalendario.Hide();
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
                RutaDTO ruta = (RutaDTO)dgvRutas.SelectedRows[0].DataBoundItem;
                if (ruta.estadoRuta)
                {
                    MessageBox.Show("La ruta ya está validada", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ruta.estadoRuta = true;
                    var response = ConexionAPI.CLIENTE.PutAsJsonAsync(ConexionAPI.Conexion + "ruta/" + ruta.IdRuta, ruta).Result;
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

        private void btnGestionValoraciones_Click(object sender, EventArgs e)
        {
            if (dgvRutas.SelectedRows.Count > 0)
            {
                RutaDTO ruta = (RutaDTO)dgvRutas.SelectedRows[0].DataBoundItem;
                GestionValoraciones gestionValoraciones = new GestionValoraciones(ruta);
                gestionValoraciones.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una ruta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCalendario_Click(object sender, EventArgs e)
        {
            CalendarioRutas calendario = new CalendarioRutas(usuario);
            calendario.ShowDialog();
        }

        private void btnMenuAdmin_Click(object sender, EventArgs e)
        {
            if (panelAdmin.Visible)
            {
                panelAdmin.Visible = false;
            }
            else
            {
                panelAdmin.Visible = true;
            }
        }

        private async void comboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            String filtro = comboFiltro.SelectedItem.ToString();
            var Rutas = await ConexionAPI.CLIENTE.GetFromJsonAsync<List<RutaDTO>>(ConexionAPI.Conexion + "ruta");
            switch (filtro)
            {
                case "Circular":
                    List<RutaDTO> rutasCirculares = Rutas.Where(r => r.clasificacion == CLASIFICACION.CIRCULAR).ToList();
                    dgvRutas.DataSource = rutasCirculares;
                    break;

                case "Lineal":
                    List<RutaDTO> rutasLineales = Rutas.Where(r => r.clasificacion == CLASIFICACION.LINEAL).ToList();
                    dgvRutas.DataSource = rutasLineales;
                    break;

                case "Accesible":
                    List<RutaDTO> rutasAccesibles = Rutas.Where(r => r.accesible == true).ToList();
                    dgvRutas.DataSource = rutasAccesibles;
                    break;

                case "Familiar":
                    List<RutaDTO> rutasFamiliares = Rutas.Where(r => r.familiar == true).ToList();
                    dgvRutas.DataSource = rutasFamiliares;
                    break;

                case "Media de 4 estrellas o mas":
                    List<RutaDTO> rutasValoradas = Rutas.Where(r => r.MediaEstrellas >= 4).ToList();
                    dgvRutas.DataSource = rutasValoradas;
                    break;

            }
        }

        private void dgvRutas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignora cabecera
            var ruta = dgvRutas.Rows[e.RowIndex].DataBoundItem as RutaDTO;
            if (ruta != null)
            {
                DetallesRuta detallesRuta = new DetallesRuta(ruta);
                detallesRuta.ShowDialog();
            }
             else
            {
                MessageBox.Show("Debe seleccionar una ruta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
