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
    public class GestionUsuariosTests
    {
        [Fact]
        public void GestionUsuarios_Load_ComboPermisosDeshabilitado()
        {
            var form = new GestionUsuarios();

            // Simulamos Load
            form.GestionUsuarios_Load(null, EventArgs.Empty);

            Assert.False(form.comboPermisos.Enabled);
        }

        // --- 2️⃣ PRUEBA DE CARGA: dgvUsuarios con lista vacía ---
        [Fact]
        public async Task CargarUsuarios_NoLanzaExcepcion()
        {
            var form = new GestionUsuarios();

            await form.CargarUsuarios();

            Assert.True(true);
        }

        // --- 3️⃣ PRUEBA DE SELECCIÓN: comboPermisos habilitado/deshabilitado ---
        [Fact]
        public void DgvUsuarios_SelectionChanged_ComboPermisos()
        {
            var form = new GestionUsuarios();

            form.GestionUsuarios_Load(null, EventArgs.Empty);

            var usuarios = new List<UsuarioDTO>
    {
        new UsuarioDTO { idUsuario = 1, rol = TIPOUSUARIO.alumno }
    };

            form.dgvUsuarios.DataSource = usuarios;
            form.dgvUsuarios.CurrentCell = form.dgvUsuarios.Rows[0].Cells[0];

            form.dgvUsuarios_SelectionChanged(null, EventArgs.Empty);

            Assert.True(form.comboPermisos.Enabled);
            Assert.Equal(TIPOUSUARIO.alumno, form.comboPermisos.SelectedItem);
        }

        // --- 4️⃣ PRUEBA DE ROBUSTEZ: Eliminar sin selección ---
        [Fact]
        public async Task Eliminar_SinSeleccion_NoLanzaExcepcion()
        {
            var form = new GestionUsuarios();
            form.dgvUsuarios.DataSource = new List<UsuarioDTO>();

            await Task.Run(() => form.Eliminar_Click(null, EventArgs.Empty));

            Assert.True(true); // Si no explota, test pasa
        }

        // --- 5️⃣ PRUEBA DE ROBUSTEZ: btnPermisos sin selección ---
        [Fact]
        public async Task BtnPermisos_SinSeleccion_NoLanzaExcepcion()
        {
            var form = new GestionUsuarios();
            form.dgvUsuarios.DataSource = new List<UsuarioDTO>();

            await Task.Run(() => form.btnPermisos_Click(null, EventArgs.Empty));

            Assert.True(true);
        }

        // --- 6️⃣ PRUEBA DE ROBUSTEZ: btnEditar sin selección ---
        [Fact]
        public void BtnEditar_SinSeleccion_NoLanzaExcepcion()
        {
            var form = new GestionUsuarios();
            form.dgvUsuarios.DataSource = new List<UsuarioDTO>();

            form.btnEditar_Click(null, EventArgs.Empty);

            Assert.True(true);
        }

        // --- 7️⃣ PRUEBA DE ROBUSTEZ: btnEditar con fila seleccionada ---
        [Fact]
        public void BtnEditar_ConFilaSeleccionada_NoLanzaExcepcion()
        {
            var form = new GestionUsuarios();

            var usuarios = new List<UsuarioDTO>
        {
            new UsuarioDTO { idUsuario = 1, rol = TIPOUSUARIO.alumno, nombre="Test", apellido="User", email="test@test.com"}
        };
            form.dgvUsuarios.DataSource = usuarios;

            // Seleccionamos la primera fila
            if (form.dgvUsuarios.Rows.Count > 0)
                form.dgvUsuarios.CurrentCell = form.dgvUsuarios.Rows[0].Cells[0];

            form.btnEditar_Click(null, EventArgs.Empty);

            Assert.True(true);
        }
    }
}
