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
    public partial class GestionValoraciones : Form
    {
        private Ruta ruta;
        public GestionValoraciones(Ruta ruta)
        {
            InitializeComponent();
            this.ruta = ruta;
            lblSelect.Text = "Seleccione valoraciones o reseñas de la ruta: " + ruta.nombre;
        }

        private async void comboValoracion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboValoracion.SelectedItem.ToString() == "Valoraciones")
            {
                var valoraciones=await ConexionAPI.CLIENTE.GetFromJsonAsync<List<Valoracion>>(ConexionAPI.Conexion + "buscar"+ruta.idRuta);


            }
            else if (comboValoracion.SelectedItem.ToString() == "Reseñas")
                {

                }

            }
        }
    }
}

