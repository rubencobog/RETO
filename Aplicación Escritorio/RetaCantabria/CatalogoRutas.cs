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
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetaCantabria
{
    public partial class CatalogoRutas : Form
    {
        
        private Usuario usuario;
        public CatalogoRutas()
        {
            this.usuario = usuario;
            InitializeComponent();
            this.Load += CatalogoRutas_Load;
        }

        private async void CatalogoRutas_Load(object sender, EventArgs e)
        {
            await CargarGrid();
        }

        public async Task CargarGrid()
        {

            var rutas = await ConexionAPI.CLIENTE.GetFromJsonAsync<List<Ruta>>(ConexionAPI.Conexion + "ruta");
            dgvRutas.AutoGenerateColumns = true;
            dgvRutas.DataSource = rutas;
            dgvRutas.Columns.RemoveAt(0);
            dgvRutas.ReadOnly = true;
            dgvRutas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnResena_Click(object sender, EventArgs e)
        {
            if (dgvRutas.SelectedRows.Count > 0)
            {
                Ruta ruta = (Ruta)dgvRutas.SelectedRows[0].DataBoundItem;
                FormResena formResena = new FormResena(usuario, ruta, ConexionAPI.CLIENTE);
                formResena.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una ruta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnValorar_Click(object sender, EventArgs e)
        {
            if (dgvRutas.SelectedRows.Count > 0)
            {
                Ruta ruta = (Ruta)dgvRutas.SelectedRows[0].DataBoundItem;
                using (FormValoracion formV= new FormValoracion())
                {
                    if(formV.ShowDialog()==DialogResult.OK)
                    {
                        Valoracion valoracion = new Valoracion
                        {
                            dificultad = formV.dificultad,
                            belleza = formV.belleza,
                            interesCultural = formV.interes,
                            fecha= DateTime.Now,
                            usuario= usuario,
                            ruta= ruta
                        };
                        var json = JsonSerializer.Serialize(valoracion);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var response = await ConexionAPI.CLIENTE.PostAsync(ConexionAPI.Conexion + "valoracion", content);
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Valoración enviada con éxito", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al enviar la valoración", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una ruta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
