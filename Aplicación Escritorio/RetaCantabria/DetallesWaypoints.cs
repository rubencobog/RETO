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
    public partial class DetallesWaypoints : Form
    {
        private RutaDTO ruta;
        public DetallesWaypoints(RutaDTO ruta)
        {
            InitializeComponent();
            this.ruta = ruta;
        }

        private async Task CargarGrid()
        {
            String uri = ConexionAPI.Conexion + $"waypoint/buscarRuta?idRuta={ruta.idRuta}";
            var respuesta = await ConexionAPI.CLIENTE.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                List<Waypoint> waypoints = await respuesta.Content.ReadFromJsonAsync<List<Waypoint>>();
                dgvWayPoint.DataSource = waypoints;
                dgvWayPoint.AutoGenerateColumns = true;
                dgvWayPoint.ReadOnly = true;
            }
        }

        private async void DetallesWaypoints_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}
