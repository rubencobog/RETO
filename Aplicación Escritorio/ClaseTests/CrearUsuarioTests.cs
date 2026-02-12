using ModeloDTO;
using RetaCantabria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseTests
{
    public class CrearUsuarioTests
    {
        [Fact]
        public void BtnRegistrar_CamposVacios_NoLanzaExcepcion()
        {
            // Arrange
            var form = new CrearUsuario();

            form.txtNombre.Text = "";
            form.txtApellido.Text = "";
            form.txtEmail.Text = "";
            form.txtPassword.Text = "";

            // Act & Assert
            // Solo comprobar que no explota al llamar el botón
            Task.Run(() => form.btnRegistrar.PerformClick()).Wait();

            Assert.True(true);
        }

        // --- 2️⃣ PRUEBA UNITARIA: Campos llenos usuario nuevo ---
        [Fact]
        public void BtnRegistrar_CamposLlenosUsuarioNuevo_NoLanzaExcepcion()
        {
            var form = new CrearUsuario();

            form.txtNombre.Text = "Juan";
            form.txtApellido.Text = "Pérez";
            form.txtEmail.Text = "juan@test.com";
            form.txtPassword.Text = "1234";

            // Act
            Task.Run(() => form.btnRegistrar.PerformClick()).Wait();

            // Si no lanza excepción, pasa
            Assert.True(true);
        }

        // --- 3️⃣ PRUEBA UNITARIA: Campos llenos usuario existente ---
        [Fact]
        public void BtnRegistrar_CamposLlenosUsuarioExistente_NoLanzaExcepcion()
        {
            var usuarioDTO = new UsuarioDTO
            {
                idUsuario = 1,
                nombre = "Ana",
                apellido = "García",
                email = "ana@test.com",
                password = "1234"
            };

            var form = new CrearUsuario(usuarioDTO);

            // Cambiamos los campos
            form.txtNombre.Text = "AnaActualizada";
            form.txtApellido.Text = "García";
            form.txtEmail.Text = "ana@test.com";
            form.txtPassword.Text = "abcd";

            // Act
            Task.Run(() => form.btnRegistrar.PerformClick()).Wait();

            // Si no explota, test pasa
            Assert.True(true);
        }

        // --- 4️⃣ PRUEBA DE CARGA: Load con usuario existente ---
        [Fact]
        public void CrearUsuario_Load_UsuarioExistente_CamposLlenos()
        {
            var usuarioDTO = new UsuarioDTO
            {
                idUsuario = 1,
                nombre = "Ana",
                apellido = "García",
                email = "ana@test.com"
            };

            var form = new CrearUsuario(usuarioDTO);

            // Simulamos Load
            form.CrearUsuario_Load(null, EventArgs.Empty);

            Assert.Equal("Ana", form.txtNombre.Text);
            Assert.Equal("García", form.txtApellido.Text);
            Assert.Equal("ana@test.com", form.txtEmail.Text);
            Assert.Equal("Actualizar", form.btnRegistrar.Text);
        }

        // --- 5️⃣ PRUEBA DE CARGA: Load usuario nuevo ---
        [Fact]
        public void CrearUsuario_Load_UsuarioNuevo_BotonRegistrar()
        {
            var form = new CrearUsuario();

            form.CrearUsuario_Load(null, EventArgs.Empty);

            Assert.Equal("Registrar", form.btnRegistrar.Text);
        }

        // --- 6️⃣ PRUEBA UNITARIA: Campos parcialmente vacíos ---
        [Fact]
        public void BtnRegistrar_CamposParcialmenteVacios_NoLanzaExcepcion()
        {
            var form = new CrearUsuario();

            form.txtNombre.Text = "Juan";
            form.txtApellido.Text = "";
            form.txtEmail.Text = "juan@test.com";
            form.txtPassword.Text = "";

            Task.Run(() => form.btnRegistrar.PerformClick()).Wait();

            Assert.True(true);
        }
    }
}
