using Conexion;
using Modelo;
using ModeloDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private RutaDTO ruta;
        public GestionValoraciones(RutaDTO ruta)
        {
            InitializeComponent();
            this.ruta = ruta;
            lblSelect.Text = "Seleccione valoraciones o reseñas de la ruta: " + ruta.nombre;
        }

        private async void comboValoracion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboValoracion.SelectedItem.ToString() == "Valoraciones")
            {
                await CargarValoracionesAsync();

            }
            else if (comboValoracion.SelectedItem.ToString() == "Reseñas")
            {
                await CargarResenasAsync();
            }
        }
        private async Task CargarValoracionesAsync()
        {
            var valoraciones = await ConexionAPI.CLIENTE.GetFromJsonAsync<List<ValoracionDevueltaDTO>>(ConexionAPI.Conexion + "valoracion/buscar/" + ruta.idRuta);
            if (valoraciones != null)
            {
                dgvValRes.DataSource = valoraciones;
                dgvValRes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvValRes.MultiSelect = false;
                dgvValRes.Columns["idValoracion"].Visible = false;
                dgvValRes.AutoGenerateColumns = true;
            }
        }

        private async Task CargarResenasAsync()
        {
            var resenas = await ConexionAPI.CLIENTE.GetFromJsonAsync<List<ResenaDevueltaDTO>>(ConexionAPI.Conexion + "resena/buscar/" + ruta.idRuta);
            if (resenas != null)
            {
                dgvValRes.DataSource = resenas;
                dgvValRes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvValRes.MultiSelect = false;
                dgvValRes.Columns["idResena"].Visible = false;
                dgvValRes.AutoGenerateColumns = true;
            }
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvValRes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una valoración o reseña para eliminar.");
            }
            else
            {
                try
                {
                    if (comboValoracion.SelectedItem.ToString() == "Valoraciones")
                    {
                        ValoracionDevueltaDTO valoracion = dgvValRes.CurrentRow.DataBoundItem as ValoracionDevueltaDTO;
                        HttpResponseMessage respuesta = await ConexionAPI.CLIENTE.DeleteAsync(ConexionAPI.Conexion + "valoracion/" + valoracion.idValoracion);
                        if (respuesta.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Valoración eliminada correctamente.");
                            await CargarValoracionesAsync();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar la valoración. " + respuesta.ReasonPhrase);
                        }

                    }
                    else if (comboValoracion.SelectedItem.ToString() == "Reseñas")
                    {
                        ResenaDevueltaDTO resena = dgvValRes.CurrentRow.DataBoundItem as ResenaDevueltaDTO;
                        HttpResponseMessage respuesta = await ConexionAPI.CLIENTE.DeleteAsync(ConexionAPI.Conexion + "resena/" + resena.idResena);
                        if (respuesta.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Reseña eliminada correctamente.");
                            await CargarResenasAsync();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar la reseña. " + respuesta.ReasonPhrase);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
            }
        }

        private void dgvValRes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var item= dgvValRes.Rows[e.RowIndex].DataBoundItem;

                if(item is ResenaDevueltaDTO resena) { 
                    MessageBox.Show($"Reseña de {resena.nomUsuario} sobre la ruta {resena.nomRuta}:\n\n{resena.resena}", "Detalle de Reseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                                MessageBox.Show("Seleccione una fila con una reseña");
            }
        }
    }
}

