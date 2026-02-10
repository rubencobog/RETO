using Conexion;
using Modelo;
using ModeloDTO;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace RetaCantabria.Tests
{
    // Test login
    [TestClass]
    public class LoginTests
    {
        //Prueba de integracion
        [TestMethod]
        public async Task LoginCredencialesOK()
        {
            HttpResponseMessage respuesta = await ConexionAPI.CLIENTE.GetAsync(ConexionAPI.Conexion + $"usuario/login?email=manolo@gmail.com&password=123"); ;

            Assert.IsTrue(respuesta.IsSuccessStatusCode);
        }

        //Prueba de integracion
        [TestMethod]
        public async Task LoginCredencialesKO()
        {
            HttpResponseMessage respuesta = await ConexionAPI.CLIENTE.GetAsync(ConexionAPI.Conexion + $"usuario/login?email=manolo@gmail.com&password=312312"); ;

            Assert.IsFalse(respuesta.IsSuccessStatusCode);
        }     
    }

    //TEST para usuarios
    [TestClass]
    public class UsuarioTests
    {

        //Prueba unitaria
        [TestMethod]
        public void CrearUsuario()
        {

            var usuario = new Usuario();


            usuario.nombre = "Ana";
            usuario.apellido = "Perez";
            usuario.email = "ana@test.com";
            usuario.password = "123";
            usuario.rol = TIPOUSUARIO.administrador;
            usuario.valoraciones = new List<Valoracion>();
            usuario.resenas = new List<Resena>();
            usuario.calendarios = new List<Calendario>();

            
            Assert.AreEqual("Ana", usuario.nombre);
            Assert.AreEqual("Perez", usuario.apellido);
            Assert.AreEqual("ana@test.com", usuario.email);
            Assert.AreEqual("123", usuario.password);
            Assert.AreEqual(TIPOUSUARIO.administrador, usuario.rol);
            Assert.IsNotNull(usuario.valoraciones);
            Assert.IsNotNull(usuario.resenas);
            Assert.IsNotNull(usuario.calendarios);
        }



        //Prueba unitaria
        [TestMethod]
        public void RoltoString()
        {
            var usuario = new Usuario
            {
                rol = TIPOUSUARIO.alumno
            };

            string json = System.Text.Json.JsonSerializer.Serialize(usuario);

            StringAssert.Contains(json, "\"rol\":\"alumno\"");
        }


        //Prueba unitaria
        [TestMethod]
        public void StringtoRol()
        {
            string json = "{\"rol\":\"administrador\"}";

            var usuario = System.Text.Json.JsonSerializer.Deserialize<Usuario>(json);

            Assert.AreEqual(TIPOUSUARIO.administrador, usuario.rol);

        }

        //Prueba de recursos
        [TestMethod]
        public async Task PruebaRendimientoCrearUsuarios()
        {

            int cantidad = 50;
            var tiempos = new List<long>();

            for (int i = 0; i < cantidad; i++)
            {
                var usuario = new Usuario
                {
                    nombre = $"DELETE {i}",
                    apellido = "Test",
                    email = $"carga{i}@test.com",
                    password = "1234",
                    rol = TIPOUSUARIO.profesor
                };

                var sw = System.Diagnostics.Stopwatch.StartNew();

                HttpResponseMessage response = await ConexionAPI.CLIENTE.PostAsJsonAsync(ConexionAPI.Conexion + "usuario", usuario);

                sw.Stop();

                tiempos.Add(sw.ElapsedMilliseconds);

                Assert.IsTrue(response.IsSuccessStatusCode);
            }

            long promedio = (long)tiempos.Average();

            Assert.IsTrue(promedio < 1500, $"Tiempo promedio alto: {promedio} ms");
        }

        //Prueba de recursos
        [TestMethod]
        public async Task PruebaMemoriaCrearUsuarios()
        {
            long memoriaAntes = GC.GetTotalMemory(true);

            await PruebaRendimientoCrearUsuarios();

            long memoriaDespues = GC.GetTotalMemory(true);

            long diferencia = memoriaDespues - memoriaAntes;

            Assert.IsTrue(diferencia < 20_000_000, $"Consumo excesivo: {diferencia} bytes");
        }

        //Prueba de recursos
        [TestMethod]
        public async Task PruebaCPUCrearUsuarios()
        {
            var proceso = System.Diagnostics.Process.GetCurrentProcess();
            var cpuAntes = proceso.TotalProcessorTime;

            await PruebaRendimientoCrearUsuarios();

            proceso.Refresh();
            var cpuDespues = proceso.TotalProcessorTime;

            var cpuUsado = cpuDespues - cpuAntes;

            Assert.IsTrue(cpuUsado.TotalSeconds < 5, $"CPU alta: {cpuUsado.TotalSeconds}s");
        }



        //Prueba de volumen y estres
        [TestMethod]
        public async Task CrearMuchosUsuarios()
        {
            int cantidadUsuarios = 100;
            for(int i = 1; i <= cantidadUsuarios; i++)
            {
                var usuarioCrear = new Usuario
                {
                    nombre = $"DELETE {i}",
                    apellido = $"Apellido{i}",
                    email = $"usuario{i}@example.com",
                    password = "1234",
                    rol = TIPOUSUARIO.alumno,
                    valoraciones = new List<Valoracion>(),
                    resenas = new List<Resena>(),
                    calendarios = new List<Calendario>()
                };

                HttpResponseMessage response = await ConexionAPI.CLIENTE.PostAsJsonAsync(ConexionAPI.Conexion + "usuario",usuarioCrear);

                Assert.IsTrue(response.IsSuccessStatusCode, $"Error al crear el usuario {i}: {response.StatusCode}");
            }


        }

        //Prueba de volumen y estres
        [TestMethod]
        public async Task EliminarMuchosUsuarios()
        {          

            var usuarios = await ConexionAPI.CLIENTE.GetFromJsonAsync<List<UsuarioDTO>>(ConexionAPI.Conexion + "usuario");

            Assert.IsNotNull(usuarios);
           
            foreach (var usuario in usuarios)
            {
                if(usuario.nombre.Contains("DELETE"))
                {
                    var resultado = await ConexionAPI.CLIENTE.DeleteAsync(ConexionAPI.Conexion + "usuario/" + usuario.idUsuario);

                    Assert.IsTrue(resultado.IsSuccessStatusCode, $"Error al eliminar usuario {usuario.idUsuario}: {resultado.StatusCode}");
                }
            }

        }

        //Prueba de funcionalidad
        [TestMethod]
        public async Task CargarUsuariosEnDataGrid()
        {
           
            var form = new GestionUsuarios();
            form.dgvUsuarios = new DataGridView();

            await form.CargarUsuarios();

            Assert.IsNotNull(form.dgvUsuarios.DataSource);

            var colId = form.dgvUsuarios.Columns["idUsuario"];
            var colPassword = form.dgvUsuarios.Columns["password"];
            if (colId != null) Assert.IsFalse(colId.Visible);
            if (colPassword != null) Assert.IsFalse(colPassword.Visible);

            Assert.AreEqual(DataGridViewAutoSizeColumnsMode.Fill, form.dgvUsuarios.AutoSizeColumnsMode);
            Assert.AreEqual(DataGridViewSelectionMode.FullRowSelect, form.dgvUsuarios.SelectionMode);
            Assert.IsFalse(form.dgvUsuarios.MultiSelect);
            Assert.IsTrue(form.dgvUsuarios.ReadOnly);

            Assert.AreEqual(0, form.dgvUsuarios.SelectedRows.Count);
        }

    }


    //Test PuntosDePeligro
    [TestClass]
    public class PuntoPeligroTests
    {
        //Prueba unitaria
        [TestMethod]
        public void CanCreatePuntoPeligroAndSetProperties()
        {
           
            var punto = new PuntoPeligro();
            var imagen = new ImagenPeligro();
          
            punto.kilometro = 12.5;
            punto.gravedad = 3;
            punto.justificacion = "Curva peligrosa";
            punto.imagenes = new List<ImagenPeligro> { imagen };
            
            Assert.AreEqual(12.5, punto.kilometro);
            Assert.AreEqual((byte)3, punto.gravedad);
            Assert.AreEqual("Curva peligrosa", punto.justificacion);
            Assert.AreEqual(1, punto.imagenes.Count);
        }
    }





}



