using Conexion;
using Modelo;
using ModeloDTO;
using System.Net.Http.Json;

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

        private async void calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime fecha = e.Start.Date;

            lblFecha.Text = $"Rutas programadas para el {fecha:dd/MM/yyyy}:";
            await CargarGrid(fecha);
        }

        private async Task CargarGrid(DateTime fecha)
        {
            dgvRutaCalendar.DataSource = null;

            HttpResponseMessage respuesta = await ConexionAPI.CLIENTE.GetAsync(ConexionAPI.Conexion + "calendario/buscar?campo=fecha&valor=" + fecha.ToString("yyyy-MM-dd"));

            if (respuesta.IsSuccessStatusCode)
            {
                List<CalendarioDTO> calendarios = await respuesta.Content.ReadFromJsonAsync<List<CalendarioDTO>>();
                List<Ruta> rutas = new List<Ruta>();
                foreach (var calendario in calendarios)
                {
                    HttpResponseMessage respuestaRuta = await ConexionAPI.CLIENTE.GetAsync(ConexionAPI.Conexion + "ruta/" + calendario.idRuta);
                    if (respuestaRuta.IsSuccessStatusCode)
                    {
                        Ruta ruta = await respuestaRuta.Content.ReadFromJsonAsync<Ruta>();
                        rutas.Add(ruta);
                    }
                    else
                    {
                        MessageBox.Show("Error al cargar la ruta con ID " + calendario.idRuta + ": " + respuestaRuta.ReasonPhrase);
                    }
                }
                dgvRutaCalendar.AutoGenerateColumns = true;
                dgvRutaCalendar.DataSource = rutas;

                foreach (DataGridViewColumn col in dgvRutaCalendar.Columns)
                {
                    col.Visible = false;
                }

                dgvRutaCalendar.Columns["nombre"].Visible = true;
                dgvRutaCalendar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvRutaCalendar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvRutaCalendar.MultiSelect = false;
                dgvRutaCalendar.ReadOnly = true;
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
                        DateTime fechaEscogida = calendar.SelectionStart.Date;
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

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRutaCalendar.SelectedRows.Count > 0)
            {
                Ruta rutaSeleccionada = (Ruta)dgvRutaCalendar.SelectedRows[0].DataBoundItem;
                DateTime fechaSeleccionada = calendar.SelectionStart.Date;
                String fecha = fechaSeleccionada.ToString("yyyy-MM-dd");
                var confirmResult = MessageBox.Show($"¿Estás seguro de que deseas eliminar la ruta '{rutaSeleccionada.nombre}' programada para el {fechaSeleccionada:yyyy/MM/dd}?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    HttpResponseMessage respuesta = ConexionAPI.CLIENTE.DeleteAsync(ConexionAPI.Conexion + $"calendario/eliminar?fecha={fecha}&idRuta={rutaSeleccionada.idRuta}").Result;
                    if (respuesta.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Ruta eliminada exitosamente.");
                        await CargarGrid(fechaSeleccionada);
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la ruta: " + respuesta.ReasonPhrase);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una ruta para eliminar.");
            }
        }

        private async void dgvRutaCalendar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Ruta rutaSeleccionada = (Ruta)dgvRutaCalendar.Rows[e.RowIndex].DataBoundItem;
                String fecha = calendar.SelectionStart.Date.ToString("yyyy-MM-dd");

                HttpResponseMessage respuesta = await ConexionAPI.CLIENTE.GetAsync(ConexionAPI.Conexion + $"calendario/busca?fecha={fecha}&idRuta={rutaSeleccionada.idRuta}");
                if (respuesta.IsSuccessStatusCode)
                {
                    CalendarioDTO calendario = await respuesta.Content.ReadFromJsonAsync<CalendarioDTO>();
                    MessageBox.Show($"Detalles de la ruta '{rutaSeleccionada.nombre}' programada para el {calendar.SelectionStart.Date:yyyy/MM/dd}:\n\nDetalles: {calendario.detalles}\nRecomendaciones: {calendario.recomendaciones}");
                }
                else
                {
                    MessageBox.Show("Error al cargar los detalles de la ruta: " + respuesta.ReasonPhrase);
                }
            }
        }
    }
}

