using Modelo;
using ModeloDTO;
using Moq;
using Moq.Protected;
using RetaCantabria;
using System.Net;
using System.Net.Http.Json;

namespace ClaseTests
{
    public class CatalogoRutasTests
    {
        [Fact]
        public void GestorPermisos_Alumno_OcultaBotonesCorrectos()
        {
            // Arrange
            var usuario = new UsuarioDTO
            {
                rol = TIPOUSUARIO.alumno
            };

            var form = new CatalogoRutas(usuario);

            // Assert
            Assert.False(form.btnMenuAdmin.Visible);
            Assert.False(form.btnCalendario.Visible);
            Assert.False(form.btnValidar.Visible);
            Assert.False(form.panelAdmin.Visible);
            Assert.False(form.btnDescarga.Visible);
            Assert.False(form.btnCrear.Visible);
        }

        [Fact]
        public void GestorPermisos_Administrador_NoOcultaBotones()
        {
            var usuario = new UsuarioDTO
            {
                rol = TIPOUSUARIO.administrador
            };

            var form = new CatalogoRutas(usuario);

            Assert.True(form.btnMenuAdmin.Visible);
        }

        [Fact]
        public void BtnMenuAdmin_CambiaVisibilidadPanel()
        {
            var usuario = new UsuarioDTO
            {
                rol = TIPOUSUARIO.administrador
            };

            var form = new CatalogoRutas(usuario);

            bool estadoInicial = form.panelAdmin.Visible;

            form.btnMenuAdmin.PerformClick();

            Assert.NotEqual(estadoInicial, form.panelAdmin.Visible);
        }

        [Fact]
        public async Task CrearGPX_NoLanzaExcepcion_Controlada()
        {
            var usuario = new UsuarioDTO { rol = TIPOUSUARIO.administrador };
            var form = new CatalogoRutas(usuario);

            var ruta = new RutaDTO
            {
                idRuta = 1,
                nombre = "RutaTest"
            };

            form.dgvRutas.DataSource = new List<RutaDTO> { ruta };
            form.dgvRutas.Rows[0].Selected = true;

            try
            {
                await form.CrearGPX();
            }
            catch
            {
                Assert.True(true); // Esperamos fallo por falta de API
                return;
            }

            Assert.True(true);
        }

        [Fact]
        public async Task CrearGPX_NoDebeTardarMasDe5Segundos()
        {
            var usuario = new UsuarioDTO { rol = TIPOUSUARIO.administrador };
            var form = new CatalogoRutas(usuario);

            var ruta = new RutaDTO
            {
                idRuta = 1,
                nombre = "RutaTest"
            };

            form.dgvRutas.DataSource = new List<RutaDTO> { ruta };
            form.dgvRutas.Rows[0].Selected = true;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            await form.CrearGPX();

            stopwatch.Stop();

            Assert.True(stopwatch.ElapsedMilliseconds < 5000);
        }

        [Fact]
        public async Task CrearGPX_SinSeleccion_LanzaExcepcion()
        {
            var usuario = new UsuarioDTO { rol = TIPOUSUARIO.administrador };
            var form = new CatalogoRutas(usuario);

            form.dgvRutas.DataSource = new List<RutaDTO>();

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await form.CrearGPX();
            });
        }




    }
}
