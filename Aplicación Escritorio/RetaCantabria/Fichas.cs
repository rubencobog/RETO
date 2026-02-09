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
    public partial class Fichas : Form
    {
        private Ruta ruta;
        public Fichas(Ruta ruta)
        {
            InitializeComponent();
            this.ruta = ruta;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cliente = new HttpClient();
            if (cbSeguridad.Checked)
            {
              crearFichaSeguridad(cliente);
            }
            if (cbUsuario.Checked)
            {
                crearFichaUsuario(cliente);
            }
            if (cbOrganizacion.Checked)
            {
                crearFichaOrganizacion(cliente);
            }
        }
        public async Task crearFichaSeguridad(HttpClient httpClient)
        {
            List<PuntoPeligro> puntosPeligro=await httpClient.GetFromJsonAsync<List<PuntoPeligro>>($"http://192.168.6.1:5050/api/puntopeligro/buscaPP?idPP={ruta.idRuta}");
            MessageBox.Show("Puntos de peligro encontrados: " + puntosPeligro.Count);
            // Recomendaciones Ruta , Media Dificultad de Puntos de Peligro(gravedad), y punto de peligro
        }
        public void crearFichaUsuario(HttpClient cliente)
        {

        }
        public void crearFichaOrganizacion(HttpClient cliente)
        {
        }
    }
}
