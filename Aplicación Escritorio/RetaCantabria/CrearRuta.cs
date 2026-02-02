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

namespace RetaCantabria
{
    public partial class CrearRuta : Form
    {
        private Usuario usuario;
        public CrearRuta(Usuario usuario)
        {
            this.usuario = usuario;
            dtpDuracion.Format = DateTimePickerFormat.Time;
            InitializeComponent();
        }

        private void rbCircular_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
