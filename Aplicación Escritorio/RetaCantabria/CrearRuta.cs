using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace RetaCantabria
{
    public partial class CrearRuta : Form
    {
        private Usuario usuario;
        public CrearRuta(Usuario usuario)
        {
            this.usuario = usuario;
           
            InitializeComponent();
            comboTemporada.Items.AddRange(new String[] { "Primavera", "Verano", "Otoño", "Invierno" });
        }


        private void btnCrear_Click(object sender, EventArgs e)
        {

        }

        private Boolean comprobarCampos()
        {
            Boolean aceptado = false;
            String nombre = txtNombre.Text;
            int distancia = Convert.ToInt32(txtDistancia.Text);
            String temporada = comboTemporada.SelectedItem.ToString();
            TimeSpan duracion = new TimeSpan(
                (int)numericHoras.Value,
                (int)numericMinutos.Value,
                (int)numericSegundos.Value
                );

            return aceptado;
        }

        private RadioButton ObtenerRadioButtonSeleccionado(GroupBox groupBox)
        {
            foreach (Control c in groupBox.Controls)
            {
                if (c is RadioButton rb && rb.Checked)
                {
                    return rb; // Este es el seleccionado
                }
            }
            return null; // Ninguno seleccionado
        }
    }
}
