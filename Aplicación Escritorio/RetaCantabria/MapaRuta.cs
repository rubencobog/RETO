using Microsoft.Web.WebView2.Core;
using Modelo;
using ModeloDTO;
using System.Data;
using System.Text.Json;

namespace RetaCantabria
{
    public partial class MapaRuta : Form
    {
        private readonly List<TrackPoint> _trackPoints;

        public MapaRuta(List<TrackPoint> trackPoints)
        {
            InitializeComponent();
            _trackPoints = trackPoints;
            this.Load += MapaRuta_Load;
        }

        private async void MapaRuta_Load(object sender, EventArgs e)
        {
            // Inicializar WebView2
            await webViewRuta.EnsureCoreWebView2Async();

            // Suscribir evento ANTES de navegar
            webViewRuta.NavigationCompleted += WebViewRuta_NavigationCompleted;

            // Cargar el HTML desde wwwroot
            string rutaHtml = Path.Combine(Application.StartupPath, "wwwroot", "HTMLmapa.html");
            webViewRuta.Source = new Uri("file:///" + rutaHtml.Replace("\\", "/"));
        }

        private async void WebViewRuta_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            // Convertir TrackPoints a lista de coordenadas
            List<CoordenadasDTO> coordenadas = _trackPoints.Select(tp => new CoordenadasDTO
            {
                lat = tp.latitud,
                lng = tp.longitud
            }).ToList();
            // Serializar a JSON
            string json = JsonSerializer.Serialize(coordenadas);

            // Limpiar caracteres que rompen JavaScript
            json = json.Replace("'", "\\'")
                       .Replace("\r", "")
                       .Replace("\n", "");

            try
            {
                // Ejecutar cuando el JS esté listo
                await EjecutarCuandoListo(
                    $"dibujarRuta(JSON.parse('{json}'))"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar datos al mapa: " + ex.Message);
            }
        }

        private async Task EjecutarCuandoListo(string script)
        {
            // Reintenta hasta que el JS esté cargado
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    await webViewRuta.ExecuteScriptAsync(script);
                    return;
                }
                catch
                {
                    await Task.Delay(100);
                }
            }

            MessageBox.Show("No se pudo ejecutar el script en el WebView.");
        }
    }

}
