using Conexion;
using Modelo;
using ModeloDTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Windows.Forms.Design.AxImporter;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

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

        public void CargarGridConLista(List<RutaDTO> rutas)
        {
            dgvRutas.DataSource = rutas;
        }
        public DataGridView GetDataGridView() { return dgvRutas; }

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
                    List<RutaDTO> rutasValoradas = Rutas.Where(r => r.mediaEstrellas >= 4).ToList();
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

        private async void btnDescarga_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            RutaDTO rutaDTO = (RutaDTO)dgvRutas.SelectedRows[0].DataBoundItem;
            string valor = "id";
            List<Ruta> ruta = await httpClient.GetFromJsonAsync<List<Ruta>>($"{ConexionAPI.Conexion}ruta/buscar?campo={valor}&valor={rutaDTO.idRuta}");
            var rutaFirst = ruta.FirstOrDefault();
            Fichas fichas = new Fichas(rutaFirst);
            fichas.ShowDialog();
        }

        private void btnEnviarGPX_Click(object sender, EventArgs e)
        {
            EnviarGPX enviarGPX = new EnviarGPX();
            enviarGPX.ShowDialog();
        }

        private async void btnGenerarGPX_Click(object sender, EventArgs e)
        {
            await CrearGPX();
        }
        public async Task CrearGPX()
        {
            RutaDTO ruta =(RutaDTO)dgvRutas.SelectedRows[0].DataBoundItem;
            HttpClient httpClient = new HttpClient();
            var nombreRuta = ruta.nombre;
            DateTime time = DateTime.Now;
            long idRuta = ruta.idRuta;
            Usuario usuario = await httpClient.GetFromJsonAsync<Usuario>($"{ConexionAPI.Conexion}usuario/buscaUsu/{idRuta}");
            List<Waypoint> wayPoints = await httpClient.GetFromJsonAsync<List<Waypoint>>($"{ConexionAPI.Conexion}waypoint/buscarRuta?idRuta={idRuta}");
            List<TrackPoint> trackPoints = await httpClient.GetFromJsonAsync<List<TrackPoint>>($"{ConexionAPI.Conexion}trackpoint/buscarRuta?idRuta={idRuta}");
            String gpx = $"""
                                <?xml version="1.0" encoding="utf-8"?>
                <gpx version="1.1" creator="ProyectoSpringBoot"
                     xmlns="http://www.topografix.com/GPX/1/1"
                     xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                     xsi:schemaLocation="http://www.topografix.com/GPX/1/1 
                                         http://www.topografix.com/GPX/1/1/gpx.xsd">
                <metadata>
                    <tipoRegistro>InfoGeneral</tipoRegistro>
                		<nombreRuta>{nombreRuta}</nombreRuta>
                		<enlaceWikiloc>www.rutas.es</enlaceWikiloc>
                        <author>{usuario.email}</author>
                		<fechaCreacionGPX>{time}</fechaCreacionGPX>
                </metadata>
                """;
            if (wayPoints.Count == 0)
            {

            }
            else
            {
                foreach (Waypoint way in wayPoints)
                {
                    gpx += $"""
                    <wpt latitud="{way.latitud}" longitud="{way.longitud} elevacion="{way.elevacion}"">
                        <timeestamp>{way.timestamp}</timestamp>
                        <nombre>{way.nombre}</nombre>
                        <descripcion>{way.descripcion}</descripcion>
                    </wpt>
                    """;
                }
            }
            if (trackPoints.Count == 0)
            {

            }
            else
            {
                foreach (TrackPoint track in trackPoints)
                {
                    gpx += $"""
                    <trk latitud="{track.latitud}" longitud="{track.longitud}" elevacion="{track.elevacion}">
                         <timeestamp>{track.timestamp}</timestamp>
                    </trk>
                    """;
                }
            }

            string rutaProyecto = Directory.GetCurrentDirectory();
            string rutaCarpeta = Path.Combine(rutaProyecto, "GPXFiles");

            if (!Directory.Exists(rutaCarpeta))
                Directory.CreateDirectory(rutaCarpeta);

            int cont = 0;
            string nombre = "generico.gpx";
            string rutaArchivo = Path.Combine(rutaCarpeta, nombre);

            while (File.Exists(rutaArchivo))
            {
                cont++;
                nombre = $"generico{cont}.gpx";
                rutaArchivo = Path.Combine(rutaCarpeta, nombre);
            }
            File.WriteAllText(rutaArchivo, gpx);

            string nombreArchivo = Path.GetFileName(rutaArchivo);
            MemoryStream archivoGPX = new MemoryStream(File.ReadAllBytes(rutaArchivo));
            MessageBox.Show($"Archivo creado correctamente en {rutaArchivo}, nombre: {nombreArchivo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
