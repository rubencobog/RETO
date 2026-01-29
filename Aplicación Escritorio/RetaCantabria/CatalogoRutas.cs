using Conexion;
using Modelo;
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

        }

        public async void CargarGrid()
        {
            List<Ruta> rutas = await cliente.GetFromJsonAsync<List<Ruta>>(ConexionAPI.Conexion + "ruta");
            dgvRutas
        }
    }
}
