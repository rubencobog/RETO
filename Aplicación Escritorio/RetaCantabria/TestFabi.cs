using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo;
using ModeloDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaCantabria
{
    
    namespace PruebasWinForms
    {
        [TestClass]
        public class TestFabiLogin
        {
            [TestMethod]
            public void LoginCorrecto()
            {
                var form = new Login();
                bool resultado = form.ValidarLogin("admin", "1234");
                Assert.IsTrue(resultado);
            }

            [TestMethod]
            public void LoginIncorrecto()
            {
                var form = new Login();
                bool resultado = form.ValidarLogin("admin", "mal");
                Assert.IsFalse(resultado);
            }
        }

        [TestClass]
        public class TestFabiNombre
        {
            [TestMethod]
            public void NombreVacio_NoEsValido()
            {
                var form = new CrearUsuario();
                bool resultado = form.ValidarNombre("");
                Assert.IsFalse(resultado);
            }

            [TestMethod]
            public void NombreMuyCorto_NoEsValido()
            {
                var form = new CrearUsuario();
                bool resultado = form.ValidarNombre("Jo");
                Assert.IsFalse(resultado);
            }

            [TestMethod]
            public void NombreCorrecto_EsValido()
            {
                var form = new CrearUsuario();
                bool resultado = form.ValidarNombre("Jorge");
                Assert.IsTrue(resultado);
            }
        }


        [TestClass]
        public class TestFabiEsValido
        {
            [TestMethod]
            public void EsValido_ContenidoVacio_DebeSerFalse()
            {
                var form = new EnviarGPX();
                form._contenido = ""; 

                bool resultado = form.esValido();

                Assert.IsFalse(resultado);
            }
        }

        [TestClass]
        public class TestFabiDGVRutas
        {
            [TestMethod]
            public void CargarGridConLista_DebeCargarDatosEnDataGridView()
            {
                var form = new CatalogoRutas(null); 
                var listaPrueba = new List<RutaDTO>()
        {
            new RutaDTO { idRuta = 1, nombre = "Ruta 1", estadoRuta = true },
            new RutaDTO { idRuta = 2, nombre = "Ruta 2", estadoRuta = true }
        };

                form.CargarGridConLista(listaPrueba);

                Assert.AreEqual(2, form.GetDataGridView().Rows.Count);
            }
        }

        [TestClass]
        public class TestDescargaFicha
        {
            [TestMethod]
            public void BotonDescarga_SeleccionCorrectaEnDataGridView()
            {
                var form = new CatalogoRutas(null);

                var listaPrueba = new List<RutaDTO>()
                {
                    new RutaDTO { idRuta = 10, nombre = "Ruta Test", estadoRuta = true }
                };

                form.CargarGridConLista(listaPrueba);

                form.GetDataGridView().Rows[0].Selected = true;

                var rutaSeleccionada = (RutaDTO)form.GetDataGridView().SelectedRows[0].DataBoundItem;

                Assert.AreEqual(10, rutaSeleccionada.idRuta);
            }
        }

        [TestClass]
        public class TestFabiNavegacion
        {
            [TestMethod]
            public void Navegar_A_FormularioCatalogoRutas_DebeCrearFormularioCorrectamente()
            {
                var form = new CatalogoRutas(null);

                Assert.IsNotNull(form);
            }
        }

        [TestClass]
        public class TestDetallesRuta
        {
            [TestMethod]
            public void CargarDatosEnLabels_DebeMostrarValoresCorrectos()
            {
                var ruta = new RutaDTO
                {
                    nombre = "Ruta Test",
                    duracion = new TimeSpan(1, 30, 0),
                    zonaGeografica = "Cantabria",
                    mediaEstrellas = 4.5,
                    clasificacion = CLASIFICACION.LINEAL,
                    distancia = 12.3,
                    accesible = true,
                    familiar = false
                };

                var form = new DetallesRuta(ruta);
                var datos = form.DatosLbl();

                Assert.AreEqual("Ruta Test", datos.nombre);
                Assert.AreEqual("01:30:00", datos.duracion);
                Assert.AreEqual("Cantabria", datos.zona);
                Assert.AreEqual("4.5", datos.media);
                Assert.AreEqual("Moderada", datos.clasificacion);
                Assert.AreEqual("12.3 km", datos.distancia);
                Assert.IsTrue(datos.accesible);
                Assert.IsFalse(datos.familiar);
            }
        }

        [TestClass]
        public class TestEnviarResena
        {
            [TestMethod]
            public void CrearResena_ResenaValida_DebeCrearObjetoCorrecto()
            {
                var usuario = new UsuarioDTO { idUsuario = 10 };
                var ruta = new RutaDTO { idRuta = 5, nombre = "Ruta Test" };
                var cliente = new HttpClient();

                var form = new FormResena(usuario, ruta, cliente);

                string texto = "Ruta espectacular";

                var resena = form.CrearResena(texto);

                Assert.IsNotNull(resena);
                Assert.AreEqual(5, resena.idRuta);
                Assert.AreEqual(10, resena.idUsuario);
                Assert.AreEqual("Ruta espectacular", resena.resena);
            }
        }

        [TestClass]
        public class TestUsoRecursos
        {
            [TestMethod]
            public void FormResena_NoDebeConsumirRecursosExcesivos()
            {
                var usuario = new UsuarioDTO { idUsuario = 10 };
                var ruta = new RutaDTO { idRuta = 5, nombre = "Ruta Test" };
                var cliente = new HttpClient();

                long memoriaAntes = GC.GetTotalMemory(true);

                var form = new FormResena(usuario, ruta, cliente);

                long memoriaDespues = GC.GetTotalMemory(true);

                Assert.IsNotNull(form);

                Assert.IsTrue(memoriaDespues - memoriaAntes < 1_000_000);
            }
        }

    }
}
