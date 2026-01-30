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
    public partial class FormValoracion : Form
    {
        public int dificultad { get; private set; }
        public int belleza { get; private set; }
        public int interes { get; private set; }

        public FormValoracion()
        {
            InitializeComponent();

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            dificultad=(int)numUDDif.Value;
            belleza=(int)numUDBelleza.Value;
            interes=(int)numUDInteres.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
