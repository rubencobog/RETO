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
    public partial class CalendarioRutas : Form
    {
        private Usuario usuario;
        public CalendarioRutas(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private async void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime fecha = calendar.SelectionStart.Date;
            lblFecha.Text = "Rutas programadas para el " + fecha.ToString("dd/MM/yyyy") + ":";
            CargarGrid(fecha);

        }

        private async void CargarGrid(DateTime fecha)
        {
            HttpResponseMessage respuesta = await ConexionAPI.CLIENTE.GetAsync(ConexionAPI.Conexion + "calendario/buscar?campo=fecha&valor=" + fecha.ToString());

            if (respuesta.IsSuccessStatusCode)
            {
                List<Calendario> calendarios = await respuesta.Content.ReadFromJsonAsync<List<Calendario>>();
                List<Ruta> rutas = new List<Ruta>();
                foreach(var calendario in calendarios)
                {
                                       HttpResponseMessage respuestaRuta = await ConexionAPI.CLIENTE.GetAsync(ConexionAPI.Conexion + "rutas/" + calendario.rutasIdruta.idRuta);
                    if (respuestaRuta.IsSuccessStatusCode)
                    {
                        Ruta ruta = await respuestaRuta.Content.ReadFromJsonAsync<Ruta>();
                        rutas.Add(ruta);
                    }
                }
                dgvRutaCalendar.DataSource = rutas;
            }
            else
            {
                MessageBox.Show("Error al cargar las rutas: " + respuesta.ReasonPhrase);
            }
        }

        private async void btnInsertarNueva_Click(object sender, EventArgs e)
        {
            if (calendar.SelectionStart.Date < DateTime.Now.Date)
            {
                MessageBox.Show("No se pueden programar rutas para fechas pasadas.");
            }
            else
            {
                using (var AgregarRutaForm = new AgregarRutaCalendario())
                {
                    if (AgregarRutaForm.ShowDialog() == DialogResult.OK)
                    {
                        DateTime fechaEscogida=calendar.SelectionStart.Date;
                        CalendarioDTO calendario = new CalendarioDTO
                        {
                            fecha = DateOnly.FromDateTime(fechaEscogida).ToString("yyyy-MM-dd"),
                            detalles = AgregarRutaForm.detalles,
                            recomendaciones = AgregarRutaForm.recomendaciones,
                            idRuta = AgregarRutaForm.rutaSeleccionada.idRuta,
                            idUsuario = this.usuario.idUsuario
                        };
                        HttpResponseMessage respuesta = ConexionAPI.CLIENTE.PostAsJsonAsync(ConexionAPI.Conexion + "calendario", calendario).Result;
                        if (respuesta.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Ruta programada exitosamente.");
                            CargarGrid(calendar.SelectionStart.Date);
                        }
                        else
                        {
                            MessageBox.Show("Error al programar la ruta: " + respuesta.ReasonPhrase);
                            Calendario calendar = await respuesta.Content.ReadFromJsonAsync<Calendario>();
                            MessageBox.Show("Detalles: " + calendar.detalles + "\nRecomendaciones: " + calendar.recomendaciones);
                        }
                    }
                }
            }
        }
    }
}

