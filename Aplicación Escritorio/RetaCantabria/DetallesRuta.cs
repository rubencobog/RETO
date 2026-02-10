using Modelo;
using ModeloDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            lblNombre.Text = ruta.Nombre;
            lblDuracion.Text = ruta.Duracion.ToString(@"hh\:mm\:ss");
            lblZona.Text = ruta.ZonaGeografica;
            lblMedia.Text = ruta.MediaEstrellas.HasValue ? ruta.MediaEstrellas.Value.ToString("0.0") : "Sin valoraciones";
            lblClasificacion.Text = ruta.clasificacion.ToString();
            lblDistancia.Text = ruta.Distancia.ToString() + " km";
            checkAccesible.Checked = ruta.accesible;
            checkFamiliar.Checked = ruta.familiar;
        }

        private void btnMapa_Click(object sender, EventArgs e)
        {
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

            MapaRuta mapaRuta = new MapaRuta(trackPoints);
            mapaRuta.ShowDialog();
        }
    }
}
