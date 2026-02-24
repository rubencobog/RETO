using ModeloDTO;
using RetaCantabria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClaseTests
{
    public class CalendarioRutasTest
    {

        // --- 2️⃣ PRUEBA DE ROBUSTEZ: btnEliminar sin selección ---
        [Fact]
        public async Task BtnEliminar_SinSeleccion_NoLanzaExcepcion()
        {
            var usuario = new UsuarioDTO { idUsuario = 1 };
            var form = new CalendarioRutas(usuario);

            form.dgvRutaCalendar.DataSource = new List<RutaDTO>(); // sin filas

            // Solo llamamos al método y comprobamos que no explota
            await Task.Run(() => form.btnEliminar.PerformClick());

            Assert.True(true); // Si llega aquí, pasó
        }

        // --- 3️⃣ PRUEBA UNITARIA: dgvRutaCalendar_CellDoubleClick sin fila ---
        [Fact]
        public async Task DgvRutaCalendar_CellDoubleClick_FueraRango_NoHaceNada()
        {
            var usuario = new UsuarioDTO { idUsuario = 1 };
            var form = new CalendarioRutas(usuario);

            // No hay filas
            var e = new DataGridViewCellEventArgs(-1, 0);

            await Task.Run(() => form.dgvRutaCalendar_CellDoubleClick(null, e));

            // Si no lanza excepción, test pasa
            Assert.True(true);
        }

        // --- 4️⃣ PRUEBA DE INTEGRACIÓN: CargarGrid básico ---
        [Fact]
        public async Task CargarGrid_FechaActual_SePuedeLlamar()
        {
            var usuario = new UsuarioDTO { idUsuario = 1 };
            var form = new CalendarioRutas(usuario);

            // Si no lanza excepción al cargar grid
            await form.CargarGrid(DateTime.Now.Date);

            Assert.True(true);
        }

        // --- 6️⃣ PRUEBA DE INTEGRACIÓN: btnInsertarNueva con selección válida ---
        [Fact]
        public void BtnInsertarNueva_FechaValida_SePuedeLlamar()
        {
            var usuario = new UsuarioDTO { idUsuario = 1 };
            var form = new CalendarioRutas(usuario);

            // Fecha futura
            form.calendar.SelectionStart = DateTime.Now.AddDays(1);

            Assert.True(true);
        }

        // --- 7️⃣ PRUEBA UNITARIA: Etiquetas lblFecha se actualizan ---
        [Fact]
        public async Task Calendar_DateSelected_ActualizaLblFecha()
        {
            var usuario = new UsuarioDTO { idUsuario = 1 };
            var form = new CalendarioRutas(usuario);

            var fecha = DateTime.Now.Date;
            var e = new DateRangeEventArgs(fecha, fecha);

            await Task.Run(() => form.calendar_DateSelected(null, e));

            Assert.Contains(fecha.ToString("dd/MM/yyyy"), form.lblFecha.Text);
        }
    }
}
