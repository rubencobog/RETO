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
    public partial class GenerarGPX : Form
    {
        private Usuario usuario;
        private Ruta ruta;
        public GenerarGPX()
        {
            InitializeComponent();

        }
        public async Task CrearGPX()
        {
            HttpClient httpClient = new HttpClient();
            var nombreRuta = "";
            DateTime time = DateTime.Now;
            long idRuta = 1;
            Usuario usuario = await httpClient.GetFromJsonAsync<Usuario>($"http://192.168.6.1:5050/api/usuario/buscaUsu?idUsuario={idRuta}");
            List <Waypoint> wayPoints = await httpClient.GetFromJsonAsync<List<Waypoint>>($"http://192.168.6.1:5050/api/waypoint/buscarRuta?idRuta={idRuta}");
            List<TrackPoint> trackPoints = await httpClient.GetFromJsonAsync<List<TrackPoint>>($"http://192.168.6.1:5050/api/trackpoint/buscarRuta?idRuta={idRuta}");
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
            foreach (TrackPoint track in trackPoints)
            {
                gpx += $"""
                    <trk latitud="{track.latitud}" longitud="{track.longitud}" elevacion="{track.elevacion}">
                         <timeestamp>{track.timestamp}</timestamp>
                    </trk>
                    """;
            }

            MessageBox.Show(gpx);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
           await CrearGPX();
        }
    }
}
