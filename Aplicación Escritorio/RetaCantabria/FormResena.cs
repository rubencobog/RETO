using Conexion;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetaCantabria
{
    public partial class FormResena : Form
    {
        private HttpClient cliente;
        private Usuario usuario;
        private Ruta ruta;
        public FormResena(Usuario usuario, Ruta ruta, HttpClient cliente)
        {
            this.cliente = cliente;
            this.usuario = usuario;
            this.ruta = ruta;
            InitializeComponent();
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            String resenatext = txtResena.Text;
            Resena resena = new Resena
            {
                resena = resenatext,
                fecha = DateOnly.FromDateTime(DateTime.Now),
                usuario = this.usuario,
                ruta = this.ruta
            };

            string json = JsonSerializer.Serialize(resena);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage respuesta = await cliente.PostAsync(ConexionAPI.Conexion + "Resena", content);

            if (respuesta.IsSuccessStatusCode)
            {
                MessageBox.Show("Reseña enviada correctamente 👍");
                Close();
            }
            else
            {
                MessageBox.Show($"Error: {respuesta.StatusCode}");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
