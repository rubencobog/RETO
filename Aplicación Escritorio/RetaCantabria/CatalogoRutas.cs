using Conexion;
using Modelo;
using ModeloDTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using static System.Windows.Forms.Design.AxImporter;
[assembly: InternalsVisibleTo("ClaseTests")]

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
            List<RutaSimplificadaDTO> rutasSimplificadas = new List<RutaSimplificadaDTO>();
            foreach(var ruta in rutas)
            {
                rutasSimplificadas.Add(new RutaSimplificadaDTO(ruta));
            }

            List<RutaSimplificadaDTO> rutasValidadas = new List<RutaSimplificadaDTO>();
            foreach (var ruta in rutasSimplificadas)
            {
                if (ruta.estadoRuta == true)
                {
                    rutasValidadas.Add(ruta);
                }
            }
            if (this.usuario.rol == TIPOUSUARIO.administrador)
            {
                dgvRutas.DataSource = rutasSimplificadas;

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
            dgvRutas.Columns["idRuta"].Visible = false;
            dgvRutas.Columns["idUsuario"].Visible = false;
            dgvRutas.ReadOnly = true;
            dgvRutas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private async void btnResena_Click(object sender, EventArgs e)
        {
            if (dgvRutas.SelectedRows.Count > 0)
            {
                RutaSimplificadaDTO ruta = (RutaSimplificadaDTO)dgvRutas.SelectedRows[0].DataBoundItem;
                RutaDTO rutaSeleccionada = await ConexionAPI.CLIENTE.GetFromJsonAsync<RutaDTO>($"{ConexionAPI.Conexion}ruta/{ruta.idRuta}");
                FormResena formResena = new FormResena(this.usuario, rutaSeleccionada, ConexionAPI.CLIENTE);
                formResena.ShowDialog();
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
                    btnGenerarGPX.Hide();
                    btnCrear.Hide();
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
                RutaSimplificadaDTO ruta = (RutaSimplificadaDTO)dgvRutas.SelectedRows[0].DataBoundItem;
                if (ruta.estadoRuta)
                {

                    MessageBox.Show("La ruta ya está validada", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RutaDTO rutaSeleccionada = await ConexionAPI.CLIENTE.GetFromJsonAsync<RutaDTO>($"{ConexionAPI.Conexion}ruta/{ruta.idRuta}");
                    rutaSeleccionada.estadoRuta = true;
                    var response = ConexionAPI.CLIENTE.PutAsJsonAsync(ConexionAPI.Conexion + "ruta/" + rutaSeleccionada.idRuta, rutaSeleccionada).Result;
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

        private async void btnGestionValoraciones_Click(object sender, EventArgs e)
        {
            if (dgvRutas.SelectedRows.Count > 0)
            {
                RutaSimplificadaDTO ruta = (RutaSimplificadaDTO)dgvRutas.SelectedRows[0].DataBoundItem;
                RutaDTO rutaSeleccionada = await ConexionAPI.CLIENTE.GetFromJsonAsync<RutaDTO>($"{ConexionAPI.Conexion}ruta/{ruta.idRuta}");
                GestionValoraciones gestionValoraciones = new GestionValoraciones(rutaSeleccionada);
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
            panelAdmin.Visible = !panelAdmin.Visible;
        }

        private async void comboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            String filtro = comboFiltro.SelectedItem.ToString();
            var Rutas = await ConexionAPI.CLIENTE.GetFromJsonAsync<List<RutaDTO>>(ConexionAPI.Conexion + "ruta");
            List<RutaSimplificadaDTO> rutasSimplificadas = new List<RutaSimplificadaDTO>();
            foreach (var ruta in Rutas) { 
                rutasSimplificadas.Add(new RutaSimplificadaDTO(ruta)); 
            }
            switch (filtro)
            {
                case "Todas": 
                    await CargarGrid();
                    break;
                case "Circular":
                    List<RutaSimplificadaDTO> rutasCirculares = rutasSimplificadas.Where(r => r.clasificacion == CLASIFICACION.CIRCULAR).ToList();
                    dgvRutas.DataSource = rutasCirculares;
                    break;

                case "Lineal":
                    List<RutaSimplificadaDTO> rutasLineales = rutasSimplificadas.Where(r => r.clasificacion == CLASIFICACION.LINEAL).ToList();
                    dgvRutas.DataSource = rutasLineales;
                    break;

                case "Accesible":
                    List<RutaSimplificadaDTO> rutasAccesibles = rutasSimplificadas.Where(r => r.accesible == true).ToList();
                    dgvRutas.DataSource = rutasAccesibles;
                    break;

                case "Familiar":
                    List<RutaSimplificadaDTO> rutasFamiliares = rutasSimplificadas.Where(r => r.familiar == true).ToList();
                    dgvRutas.DataSource = rutasFamiliares;
                    break;

                case "Media de 4 estrellas o mas":
                    List<RutaSimplificadaDTO> rutasValoradas = rutasSimplificadas.Where(r => r.mediaEstrellas >= 4).ToList();
                    dgvRutas.DataSource = rutasValoradas;
                    break;

            }
        }

        private async void dgvRutas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var ruta = dgvRutas.Rows[e.RowIndex].DataBoundItem as RutaSimplificadaDTO;
            if (ruta != null)
            {
                RutaDTO rutaSeleccionada = await ConexionAPI.CLIENTE.GetFromJsonAsync<RutaDTO>($"{ConexionAPI.Conexion}ruta/{ruta.idRuta}");

                DetallesRuta detallesRuta = new DetallesRuta(rutaSeleccionada, usuario);
                detallesRuta.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una ruta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDescarga_Click(object sender, EventArgs e)
        {
            RutaSimplificadaDTO rutaDTO = (RutaSimplificadaDTO)dgvRutas.SelectedRows[0].DataBoundItem;
            string valor = "id";
            List<Ruta> ruta = await ConexionAPI.CLIENTE.GetFromJsonAsync<List<Ruta>>($"{ConexionAPI.Conexion}ruta/buscar?campo={valor}&valor={rutaDTO.idRuta}");
            var rutaFirst = ruta.FirstOrDefault();
            Fichas fichas = new Fichas(rutaFirst);
            fichas.ShowDialog();
        }

        private async void btnGenerarGPX_Click(object sender, EventArgs e)
        {
            await CrearGPX();
        }
        public async Task CrearGPX()
        {
            RutaSimplificadaDTO ruta = (RutaSimplificadaDTO)dgvRutas.SelectedRows[0].DataBoundItem;
            var nombreRuta = ruta.nombre;
            DateTime time = DateTime.Now;
            long idRuta = ruta.idRuta;
            Usuario usuario = await ConexionAPI.CLIENTE.GetFromJsonAsync<Usuario>($"{ConexionAPI.Conexion}usuario/buscaUsu/{ruta.idUsuario}");

            List<Waypoint> wayPoints = await ConexionAPI.CLIENTE.GetFromJsonAsync<List<Waypoint>>($"{ConexionAPI.Conexion}waypoint/buscarRuta?idRuta={idRuta}");
            List<TrackPoint> trackPoints = await ConexionAPI.CLIENTE.GetFromJsonAsync<List<TrackPoint>>($"{ConexionAPI.Conexion}trackpoint/buscarRuta?idRuta={idRuta}");
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
