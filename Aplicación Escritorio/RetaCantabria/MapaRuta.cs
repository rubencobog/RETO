using Microsoft.Web.WebView2.Core;
using Modelo;
using ModeloDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetaCantabria
{
    public partial class MapaRuta : Form
    {
        private readonly List<TrackPoint> _trackPoints;

        public MapaRuta(List<TrackPoint> trackPoints)
        {
            InitializeComponent();
            _trackPoints = trackPoints;
        }

        private async void MapaRuta_Load(object sender, EventArgs e)
        {
            await webViewRuta.EnsureCoreWebView2Async();

            string rutaHtml = Path.Combine(
                Application.StartupPath,
                "wwwroot",
                "HTMLmapa.html"
            );

            webViewRuta.Source = new Uri(rutaHtml);

            // Registrar el evento después de asignar Source
            webViewRuta.NavigationCompleted += WebViewRuta_NavigationCompleted;
        }

        private async void WebViewRuta_NavigationCompleted(
            object sender,
            CoreWebView2NavigationCompletedEventArgs e)
        {
            // Proyectamos solo lat/lng
            var puntosMapa = _trackPoints
                .Select(tp => new CoordenadasDTO
                {
                    lat = tp.latitud,
                    lng = tp.longitud
                })
                .ToList();

            string json = JsonSerializer.Serialize(puntosMapa);

            try
            {
                await webViewRuta.ExecuteScriptAsync(
                    $"dibujarRuta({json})"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar datos al mapa: " + ex.Message);
            }
        }
    }
}
