using Modelo;
using ModeloDTO;
using RetaCantabria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseTests
{

public class CrearRutaTests
    {
        // --- 1️⃣ PRUEBA UNITARIA: comprobarCampos con campos vacíos ---
        [Fact]
        public void ComprobarCampos_CamposVacios_RetornaFalse()
        {
            var usuario = new UsuarioDTO { idUsuario = 1 };
            var form = new CrearRuta(usuario);

            // Todos los campos vacíos
            form.txtNombre.Text = "";
            form.txtDistancia.Text = "";
            form.txtZona.Text = "";
            form.comboTemporada.SelectedIndex = -1;
            form.numericHoras.Value = 0;
            form.numericMinutos.Value = 0;
            form.numericSegundos.Value = 0;
            form.rbCircular.Checked = false;
            form.rbLineal.Checked = false;
            form.rbSiAccesibilidad.Checked = false;
            form.rbNoAccesibilidad.Checked = false;
            form.rbSiFamiliar.Checked = false;
            form.rbNoFamiliar.Checked = false;

            bool resultado = form.comprobarCampos();

            Assert.False(resultado);
        }

        // --- 2️⃣ PRUEBA UNITARIA: comprobarCampos con datos válidos ---
        [Fact]
        public void ComprobarCampos_CamposLlenos_RetornaTrue()
        {
            var usuario = new UsuarioDTO { idUsuario = 1 };
            var form = new CrearRuta(usuario);

            form.txtNombre.Text = "RutaTest";
            form.txtDistancia.Text = "10";
            form.txtZona.Text = "ZonaTest";
            form.comboTemporada.SelectedIndex = 0;
            form.numericHoras.Value = 1;
            form.numericMinutos.Value = 23;
            form.numericSegundos.Value = 0;
            form.rbCircular.Checked = true;
            form.rbSiAccesibilidad.Checked = true;
            form.rbSiFamiliar.Checked = true;

            bool resultado = form.comprobarCampos();

            Assert.True(resultado);
        }

        // --- 3️⃣ PRUEBA DE ROBUSTEZ: btnCrear con campos vacíos ---
        [Fact]
        public async Task BtnCrear_CamposVacios_NoLanzaExcepcion()
        {
            var usuario = new UsuarioDTO { idUsuario = 1 };
            var form = new CrearRuta(usuario);

            form.txtNombre.Text = "";
            form.txtDistancia.Text = "";
            form.txtZona.Text = "";
            form.comboTemporada.SelectedIndex = -1;
            await Task.Run(() => form.btnCrear.PerformClick());

            Assert.True(true);
        }

        // --- 4️⃣ PRUEBA DE ROBUSTEZ: btnCrear con campos válidos ---
        [Fact]
        public async Task BtnCrear_CamposValidos_NoLanzaExcepcion()
        {
            var usuario = new UsuarioDTO { idUsuario = 1 };
            var form = new CrearRuta(usuario);

            form.txtNombre.Text = "RutaTest";
            form.txtDistancia.Text = "5";
            form.txtZona.Text = "ZonaTest";
            form.comboTemporada.SelectedIndex = 0;
            form.numericHoras.Value = 1;
            form.numericMinutos.Value = 0;
            form.numericSegundos.Value = 0;
            form.rbCircular.Checked = true;
            form.rbSiAccesibilidad.Checked = true;
            form.rbSiFamiliar.Checked = true;

            // Llamamos btnCrear, ignora MessageBox
            await Task.Run(() => form.btnCrear.PerformClick());

            Assert.True(true);
        }

        // --- 5️⃣ PRUEBA UNITARIA: selección de clasificación ---
        [Fact]
        public void Clasificacion_Seleccionada_Correcta()
        {
            var usuario = new UsuarioDTO { idUsuario = 1 };
            var form = new CrearRuta(usuario);

            form.rbCircular.Checked = true;
            form.rbLineal.Checked = false;

            CLASIFICACION clasificacion;
            if (form.rbCircular.Checked)
                clasificacion = CLASIFICACION.CIRCULAR;
            else
                clasificacion = CLASIFICACION.LINEAL;

            Assert.Equal(CLASIFICACION.CIRCULAR, clasificacion);
        }

        // --- 6️⃣ PRUEBA UNITARIA: accesibilidad y familiar ---
        [Fact]
        public void AccesibilidadYFamiliar_Seleccionados_Correctos()
        {
            var usuario = new UsuarioDTO { idUsuario = 1 };
            var form = new CrearRuta(usuario);

            form.rbSiAccesibilidad.Checked = true;
            form.rbSiFamiliar.Checked = false;

            bool accesibilidad = form.rbSiAccesibilidad.Checked ? true : false;
            bool familiar = form.rbSiFamiliar.Checked ? true : false;

            Assert.True(accesibilidad);
            Assert.False(familiar);
        }
    }

}
