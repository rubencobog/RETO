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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetaCantabria
{
    public partial class CatalogoRutas : Form
    {
        private readonly HttpClient cliente = new HttpClient();
        public CatalogoRutas()
        {
            InitializeComponent();
            this.Load += CatalogoRutas_Load;

        }

        private async void CatalogoRutas_Load(object sender, EventArgs e)
        {
            await CargarGrid();
        }

        public async Task CargarGrid()
        {
            var rutas = await cliente.GetFromJsonAsync<List<Ruta>>("http://localhost:5050/api/ruta");
            dgvRutas.AutoGenerateColumns = true;
            dgvRutas.DataSource = rutas;
            dgvRutas.Columns.RemoveAt(0);
            dgvRutas.ReadOnly = true;
            dgvRutas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
