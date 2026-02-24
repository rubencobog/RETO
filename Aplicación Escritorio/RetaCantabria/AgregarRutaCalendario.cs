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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetaCantabria
{
    public partial class AgregarRutaCalendario : Form
    {
        public String detalles { get; set; }
        public String recomendaciones { get; set; }
        public RutaDTO rutaSeleccionada { get; set; }
        public AgregarRutaCalendario()
        {
            InitializeComponent();
            this.Load += AgregarRutaCalendario_Load;

        }


        private async Task CargarGrid()
        {
            var rutas = await ConexionAPI.CLIENTE.GetFromJsonAsync<List<RutaDTO>>(ConexionAPI.Conexion + "ruta");
            dgvRutasDisponibles.DataSource = rutas;
            dgvRutasDisponibles.AutoGenerateColumns = true;
            dgvRutasDisponibles.Columns.RemoveAt(0);
            dgvRutasDisponibles.Columns["idUsuario"].Visible = false;
            dgvRutasDisponibles.ReadOnly = true;
            dgvRutasDisponibles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private async void AgregarRutaCalendario_Load(object sender, EventArgs e)
        {
            await CargarGrid();
        }

        private void btnInsertarRuta_Click(object sender, EventArgs e)
        {
            if (dgvRutasDisponibles.SelectedRows.Count > 0)
            {
                rutaSeleccionada = (RutaDTO)dgvRutasDisponibles.SelectedRows[0].DataBoundItem;
                detalles = txtDetalles.Text;
                recomendaciones = txtRecomendaciones.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una ruta para agregar al calendario.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
