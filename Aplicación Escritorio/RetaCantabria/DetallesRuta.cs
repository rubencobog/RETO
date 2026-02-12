using Conexion;
using Modelo;
using ModeloDTO;
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
    public partial class DetallesRuta : Form
    {
        private RutaDTO ruta;
        public DetallesRuta(RutaDTO ruta)
        {
            InitializeComponent();
            this.ruta = ruta;
        }

        private void DetallesRuta_Load(object sender, EventArgs e)
        {
            lblNombre.Text = ruta.nombre;
            lblDuracion.Text = ruta.duracion.ToString(@"hh\:mm\:ss");
            lblZona.Text = ruta.zonaGeografica;
            lblMedia.Text = ruta.mediaEstrellas.HasValue ? ruta.mediaEstrellas.Value.ToString("0.0") : "Sin valoraciones";
            lblClasificacion.Text = ruta.clasificacion.ToString();
            lblDistancia.Text = ruta.distancia.ToString() + " km";
            checkAccesible.Checked = ruta.accesible;
            checkFamiliar.Checked = ruta.familiar;
        }
        public void DetallesRuta_Cargar(object sender, EventArgs e)
        {
            lblNombre.Text = ruta.nombre;
            lblDuracion.Text = ruta.duracion.ToString(@"hh\:mm\:ss");
            lblZona.Text = ruta.zonaGeografica;
            lblMedia.Text = ruta.mediaEstrellas.HasValue ? ruta.mediaEstrellas.Value.ToString("0.0") : "Sin valoraciones";
            lblClasificacion.Text = ruta.clasificacion.ToString();
            lblDistancia.Text = ruta.distancia.ToString() + " km";
            checkAccesible.Checked = ruta.accesible;
            checkFamiliar.Checked = ruta.familiar;
        }
        public (string nombre, string duracion, string zona, string media, string clasificacion, string distancia, bool accesible, bool familiar)
    DatosLbl()
        {
            return (
                ruta.nombre,
                ruta.duracion.ToString(@"hh\:mm\:ss"),
                ruta.zonaGeografica,
                ruta.mediaEstrellas.HasValue ? ruta.mediaEstrellas.Value.ToString("0.0") : "Sin valoraciones",
                ruta.clasificacion.ToString(),
                ruta.distancia.ToString() + " km",
                ruta.accesible,
                ruta.familiar
            );
        }


        private async void btnMapa_Click(object sender, EventArgs e)
        {
            var respuesta = await ConexionAPI.CLIENTE.GetAsync(ConexionAPI.Conexion + $"trackpoint/buscarRuta?idRuta={ruta.idRuta}");

            if (!respuesta.IsSuccessStatusCode)
            {
                MessageBox.Show("Error al cargar la ruta. " + respuesta.ReasonPhrase);
                return;
            }

            var tPoints = await respuesta.Content.ReadFromJsonAsync<List<TrackPoint>>();

            if (tPoints == null)
            {
                MessageBox.Show("La ruta no contiene puntos.");
                return;
            }

            var trackPoints = new List<TrackPoint>
{
    new TrackPoint
    {
        idPuntoRuta = 1,
        latitud = 40.416775,
        longitud = -3.703790,
        elevacion = 667,
        timestamp = DateTime.Now.AddMinutes(-20),
        ruta = null
    },
    new TrackPoint
    {
        idPuntoRuta = 2,
        latitud = 40.417350,
        longitud = -3.704200,
        elevacion = 668,
        timestamp = DateTime.Now.AddMinutes(-18),
        ruta = null
    },
    new TrackPoint
    {
        idPuntoRuta = 3,
        latitud = 40.418120,
        longitud = -3.705100,
        elevacion = 670,
        timestamp = DateTime.Now.AddMinutes(-15),
        ruta = null
    },
    new TrackPoint
    {
        idPuntoRuta = 4,
        latitud = 40.419050,
        longitud = -3.706400,
        elevacion = 671,
        timestamp = DateTime.Now.AddMinutes(-12),
        ruta = null
    },
    new TrackPoint
    {
        idPuntoRuta = 5,
        latitud = 40.420100,
        longitud = -3.708000,
        elevacion = 672,
        timestamp = DateTime.Now.AddMinutes(-9),
        ruta = null
    },
    new TrackPoint
    {
        idPuntoRuta = 6,
        latitud = 40.421200,
        longitud = -3.709800,
        elevacion = 674,
        timestamp = DateTime.Now.AddMinutes(-6),
        ruta = null
    },
    new TrackPoint
    {
        idPuntoRuta = 7,
        latitud = 40.422350,
        longitud = -3.711600,
        elevacion = 675,
        timestamp = DateTime.Now.AddMinutes(-3),
        ruta = null
    }
};

            MapaRuta mapaRuta = new MapaRuta(tPoints);
            mapaRuta.ShowDialog();
        }

        private void btnWaypoints_Click(object sender, EventArgs e)
        {
            DetallesWaypoints detalles = new DetallesWaypoints(ruta);
            detalles.ShowDialog();
        }
    }
}
