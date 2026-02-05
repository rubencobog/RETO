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


        private async void btnCrear_Click(object sender, EventArgs e)
        {
            if (comprobarCampos())
            {
                CLASIFICACION clasificacion;
                if (rbCircular.Checked)
                {
                    clasificacion = CLASIFICACION.CIRCULAR;
                }
                else
                {
                    clasificacion = CLASIFICACION.LINEAL;
                }
                Boolean accesibilidad;
                if (rbNoAccesibilidad.Checked)
                {
                    accesibilidad = false;
                }
                else                 {
                    accesibilidad = true;
                }

                Boolean familiar;
                if (rbNoFamiliar.Checked)
                {
                    familiar = false;
                }
                else
                {
                    familiar = true;
                }

                Ruta ruta = new Ruta
                {
                    nombre=txtNombre.Text,
                    distancia=Convert.ToInt32(txtDistancia.Text),
                    temporadas=comboTemporada.SelectedItem.ToString(),
                    zonaGeografica=txtZona.Text,
                    duracion=new TimeOnly(
                        (int)numericHoras.Value,
                        (int)numericMinutos.Value,
                        (int)numericSegundos.Value
                        ),
                    clasificacion=clasificacion,
                    accesibilidad=accesibilidad,
                    rutaFamiliar=familiar,
                    recomendacionesEquipo=txtRecomendaciones.Text,
                };

               // HttpResponseMessage

            }
            else
            {
                MessageBox.Show("Rellena todos los campos");
            }

        }

        private Boolean comprobarCampos()
        {
            Boolean aceptado = false;


            String nombre = txtNombre.Text;
            int distancia = 0;
            if (!String.IsNullOrEmpty(txtDistancia.Text))
            {
                distancia = Convert.ToInt32(txtDistancia.Text);
            }
            String temporada = "";
            if (comboTemporada.SelectedIndex >= 0)
            {
                temporada = comboTemporada.SelectedItem.ToString();
            }
            String zonaGeografica = txtZona.Text;
            TimeSpan duracion = new TimeSpan(
                (int)numericHoras.Value,
                (int)numericMinutos.Value,
                (int)numericSegundos.Value
                );
            
            CLASIFICACION clasificacion;
            if (rbCircular.Checked)
            {
                clasificacion=CLASIFICACION.CIRCULAR;
            }else if(rbLineal.Checked)
            {
                clasificacion=CLASIFICACION.LINEAL;
            }
            else
            {
                MessageBox.Show("Selecciona una clasificación");
                return false;
            }
            Boolean accesibilidad;
            if (rbNoAccesibilidad.Checked)
            {
                accesibilidad = false;
            }
            else if (rbSiAccesibilidad.Checked)
            {
                accesibilidad = true;
            }
            else
            {
                MessageBox.Show("Selecciona si la ruta es accesible o no");
                return false;
            }
            Boolean familiar;
            if (rbNoFamiliar.Checked)
            {
                familiar = false;
            }
            else if (rbSiFamiliar.Checked)
            {
                familiar = true;
            }
            else
            {
                MessageBox.Show("Selecciona si la ruta es familiar o no");
                return false;
            }

                if (!String.IsNullOrEmpty(nombre) && !String.IsNullOrEmpty(temporada) && !String.IsNullOrEmpty(zonaGeografica) && distancia!=null && duracion!=TimeSpan.Zero && distancia!=0)
            {
                aceptado = true;
            }
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
