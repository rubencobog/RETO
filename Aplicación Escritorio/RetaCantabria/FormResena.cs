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
        private UsuarioDTO usuario;
        private RutaDTO ruta;
        public FormResena(UsuarioDTO usuario, RutaDTO ruta, HttpClient cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            this.usuario = usuario;
            this.ruta = ruta;
            lblResena.Text = "Reseña de " + ruta.nombre;
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            String resenatext = txtResena.Text;
            if (!String.IsNullOrWhiteSpace(resenatext))
            {
                ResenaDTO resena = new ResenaDTO
            {
                    idRuta = ruta.idRuta,
                idUsuario = usuario.idUsuario,
                resena = resenatext,
                fecha = DateOnly.FromDateTime(DateTime.Now)
                };

                HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(ConexionAPI.Conexion + "resena", resena);

                if (respuesta.IsSuccessStatusCode)
                {
                    MessageBox.Show("Reseña enviada correctamente");
                    Close();
                }
                else
                {
                    MessageBox.Show($"Error: {respuesta.StatusCode}");
                }
            } else {
                MessageBox.Show("La reseña no puede estar vacía.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
