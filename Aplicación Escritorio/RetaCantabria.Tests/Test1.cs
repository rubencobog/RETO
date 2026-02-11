using Conexion;
using Modelo;
using ModeloDTO;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace RetaCantabria.Tests
{
    //Test API
    [TestClass]
    public class ConexionAPITests
    {
        //Prueba de integracion
        [TestMethod]
        public async Task ConexionAPIValida()
        {

            var cliente = ConexionAPI.CLIENTE;

            var respuesta = await cliente.GetAsync(ConexionAPI.Conexion + "actividad/test");

            Assert.IsTrue(respuesta.IsSuccessStatusCode, $"No hay conexión con la API");
        }

        //Prueba de recursos
        [TestMethod]
        public async Task ConexionAPITiempo()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();

            var respuesta = await ConexionAPI.CLIENTE.GetAsync(ConexionAPI.Conexion + "usuario");

            sw.Stop();

            Assert.IsTrue(respuesta.IsSuccessStatusCode, $"La API tarda : {sw.ElapsedMilliseconds} ms en responder");
        }

        //Prueba de integracion
        [TestMethod]
        public async Task ObtenerUsuarios()
        {

            var cliente = ConexionAPI.CLIENTE;

            var usuarios = await cliente.GetFromJsonAsync<List<UsuarioDTO>>(ConexionAPI.Conexion + "usuario");

            Assert.IsNotNull(usuarios, "La API devolvió null");
            Assert.IsTrue(usuarios.Count > 0, "La API no devolvió usuarios");

            var primero = usuarios.First();

            Assert.IsTrue(primero.idUsuario > 0);
            Assert.IsFalse(string.IsNullOrEmpty(primero.email));
            Assert.IsFalse(string.IsNullOrEmpty(primero.nombre));
        }

        //Prueba de recursos
        [TestMethod]
        public async Task ObtenerUsuariosRespuestaRapida()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();

            var usuarios = await ConexionAPI.CLIENTE.GetFromJsonAsync<List<UsuarioDTO>>(ConexionAPI.Conexion + "usuario");

            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds < 1500, $"La API tardó: {sw.ElapsedMilliseconds} ms");
        }


        //Prueba de integracion
        [TestMethod]
        public async Task CrearRutaCompleta()
        {

            var ruta = new Ruta
            {
                nombre = "TEST RUTA",
                nombreInicioruta = "Inicio",
                nombreFinalruta = "Final",
                latitudInicial = 43.46,
                latitudFinal = 43.47,
                longitudInicial = -3.80,
                longitudFinal = -3.79,
                distancia = 12.5,
                duracion = new TimeOnly(2, 30),
                desnivelPositivo = 500,
                desnivelNegativo = 480,
                desnivelAcumulado = 980,
                altitudMax = 1200,
                altitudMin = 300,
                clasificacion = CLASIFICACION.LINEAL,
                nivelEsfuerzo = 3,
                nivelRiesgo = 2,
                estadoRuta = true,
                tipoTerreno = 1,
                indicaciones = 1,
                temporadas = "Verano",
                accesibilidad = false,
                rutaFamiliar = false,
                archivoGPX = "test.gpx",
                recomendacionesEquipo = "Botas",
                zonaGeografica = "Cantabria",
                mediaEstrellas = 0
            };


            HttpResponseMessage respuesta = await ConexionAPI.CLIENTE.PostAsJsonAsync(ConexionAPI.Conexion + "ruta", ruta);

            Assert.IsTrue(respuesta.IsSuccessStatusCode, $"Error al crear la ruta: {respuesta.StatusCode}"
            );
        }

        //Prueba de integracion
        [TestMethod]
        public async Task CrearResena()
        {

            var resena = new ResenaDTO
            {
                idRuta = 1,
                idUsuario = 1,
                resena = "Reseña de prueba desde test",
                fecha = DateOnly.FromDateTime(DateTime.Now)
            };

            HttpResponseMessage respuesta = await ConexionAPI.CLIENTE.PostAsJsonAsync(ConexionAPI.Conexion + "resena", resena);

            Assert.IsTrue(
                respuesta.IsSuccessStatusCode, $"Error al crear la reseña: {respuesta.StatusCode}"
            );
        }


        [TestMethod]

        public async Task ObtenerImagenPeligro()
        {
            var cliente = ConexionAPI.CLIENTE;

            var respuesta = await cliente.GetAsync(ConexionAPI.Conexion + "test");

            Assert.IsTrue(respuesta.IsSuccessStatusCode, "La API no conecta con ImagenPeligro");

        }

    }


    // Test login
    [TestClass]
    public class LoginTests
    {
        //Prueba de seguridad
        [TestMethod]
        public async Task LoginCredencialesOK()
        {
            HttpResponseMessage respuesta = await ConexionAPI.CLIENTE.GetAsync(ConexionAPI.Conexion + $"usuario/login?email=manolo@gmail.com&password=123"); ;

            Assert.IsTrue(respuesta.IsSuccessStatusCode);
        }

        //Prueba de seguridad
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
                    email = $"test{i}@test.com",
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
            for (int i = 1; i <= cantidadUsuarios; i++)
            {
                var usuarioCrear = new Usuario
                {
                    nombre = $"DELETE {i}",
                    apellido = $"Apellido{i}",
                    email = $"usuario{i}@test.com",
                    password = "1234",
                    rol = TIPOUSUARIO.alumno,
                    valoraciones = new List<Valoracion>(),
                    resenas = new List<Resena>(),
                    calendarios = new List<Calendario>()
                };

                HttpResponseMessage response = await ConexionAPI.CLIENTE.PostAsJsonAsync(ConexionAPI.Conexion + "usuario", usuarioCrear);

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
                if (usuario.nombre.Contains("DELETE"))
                {
                    var resultado = await ConexionAPI.CLIENTE.DeleteAsync(ConexionAPI.Conexion + "usuario/" + usuario.idUsuario);

                    Assert.IsTrue(resultado.IsSuccessStatusCode, $"Error al eliminar usuario {usuario.idUsuario}: {resultado.StatusCode}");
                }
            }

        }


        //Test PuntosDePeligro
        [TestClass]
        public class PuntoPeligroTests
        {
            //Prueba unitaria
            [TestMethod]
            public void CrearPuntoPeligro()
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



        [TestClass]
        public class RutaTests
        {

            //Prueba unitaria
            [TestMethod]
            public void RutaAsignarValores()
            {

                var usuario = new Usuario { email = "test@test.com" };
                var puntos = new List<PuntoRuta>();
                var valoraciones = new List<Valoracion>();
                var resenas = new List<Resena>();

                var ruta = new Ruta
                {
                    nombre = "Ruta Test",
                    nombreInicioruta = "Inicio",
                    nombreFinalruta = "Final",
                    latitudInicial = 43.1,
                    latitudFinal = 43.5,
                    longitudInicial = -3.8,
                    longitudFinal = -3.5,
                    distancia = 12.3,
                    duracion = new TimeOnly(2, 30),
                    desnivelPositivo = 400,
                    desnivelNegativo = 380,
                    desnivelAcumulado = 780,
                    altitudMax = 1200,
                    altitudMin = 200,
                    clasificacion = CLASIFICACION.CIRCULAR,
                    nivelEsfuerzo = 3,
                    nivelRiesgo = 2,
                    estadoRuta = true,
                    tipoTerreno = 1,
                    indicaciones = 1,
                    temporadas = "Primavera-Verano",
                    accesibilidad = true,
                    rutaFamiliar = false,
                    archivoGPX = "ruta.gpx",
                    recomendacionesEquipo = "Agua y botas",
                    zonaGeografica = "Cantabria",
                    mediaEstrellas = 4.5,
                    usuarioIdusuario = usuario,
                    puntos = puntos,
                    valoraciones = valoraciones,
                    resenas = resenas
                };


                Assert.AreEqual("Ruta Test", ruta.nombre);
                Assert.AreEqual("Inicio", ruta.nombreInicioruta);
                Assert.AreEqual("Final", ruta.nombreFinalruta);
                Assert.AreEqual(43.1, ruta.latitudInicial);
                Assert.AreEqual(43.5, ruta.latitudFinal);
                Assert.AreEqual(-3.8, ruta.longitudInicial);
                Assert.AreEqual(-3.5, ruta.longitudFinal);
                Assert.AreEqual(12.3, ruta.distancia);
                Assert.AreEqual(new TimeOnly(2, 30), ruta.duracion);
                Assert.AreEqual(400, ruta.desnivelPositivo);
                Assert.AreEqual(380, ruta.desnivelNegativo);
                Assert.AreEqual(780, ruta.desnivelAcumulado);
                Assert.AreEqual(1200, ruta.altitudMax);
                Assert.AreEqual(200, ruta.altitudMin);
                Assert.AreEqual(CLASIFICACION.CIRCULAR, ruta.clasificacion);
                Assert.AreEqual((byte)3, ruta.nivelEsfuerzo);
                Assert.AreEqual((byte)2, ruta.nivelRiesgo);
                Assert.IsTrue(ruta.estadoRuta);
                Assert.AreEqual((byte)1, ruta.tipoTerreno);
                Assert.AreEqual((byte)1, ruta.indicaciones);
                Assert.AreEqual("Primavera-Verano", ruta.temporadas);
                Assert.IsTrue(ruta.accesibilidad);
                Assert.IsFalse(ruta.rutaFamiliar);
                Assert.AreEqual("ruta.gpx", ruta.archivoGPX);
                Assert.AreEqual("Agua y botas", ruta.recomendacionesEquipo);
                Assert.AreEqual("Cantabria", ruta.zonaGeografica);
                Assert.AreEqual(4.5, ruta.mediaEstrellas);
                Assert.AreEqual(usuario, ruta.usuarioIdusuario);
                Assert.AreEqual(puntos, ruta.puntos);
                Assert.AreEqual(valoraciones, ruta.valoraciones);
                Assert.AreEqual(resenas, ruta.resenas);
            }


        }







        //Tests para actividades
        [TestClass]
        public class ActividadTests
        {

            //Prueba unitaria
            [TestMethod]
            public void CreaActividad()
            {

                var ruta = new Ruta
                {
                    idRuta = 5,
                    nombre = "Ruta Prueba"
                };

                var actividad = new Actividad
                {
                    id = 1,
                    nombre = "Senderismo",
                    rutasIdruta = ruta
                };


                Assert.AreEqual(1, actividad.id);
                Assert.AreEqual("Senderismo", actividad.nombre);
                Assert.IsNotNull(actividad.rutasIdruta);
                Assert.AreEqual(5, actividad.rutasIdruta.idRuta);
                Assert.AreEqual("Ruta Prueba", actividad.rutasIdruta.nombre);
            }
        }


        //Tests Calendario
        [TestClass]
        public class CalendarioTests
        {

            //Prueba unitaria
            [TestMethod]
            public void CrearCalendario()
            {

                var ruta = new Ruta { idRuta = 10, nombre = "Ruta Costa" };
                var usuario = new Usuario { idUsuario = 3, nombre = "Ana" };

                var calendario = new Calendario
                {
                    fecha = new DateOnly(2026, 5, 10),
                    detalles = "Salida con grupo",
                    recomendaciones = "Llevar agua",
                    rutasIdruta = ruta,
                    usuarioIdusuario = usuario
                };


                Assert.AreEqual(new DateOnly(2026, 5, 10), calendario.fecha);
                Assert.AreEqual("Salida con grupo", calendario.detalles);
                Assert.AreEqual("Llevar agua", calendario.recomendaciones);
                Assert.IsNotNull(calendario.rutasIdruta);
                Assert.AreEqual(10, calendario.rutasIdruta.idRuta);
                Assert.IsNotNull(calendario.usuarioIdusuario);
                Assert.AreEqual(3, calendario.usuarioIdusuario.idUsuario);
            }
        }

        //Tests Valores
        [TestClass]
        public class ValoracionTests
        {
            [TestMethod]
            public void CrearValoracion()
            {

                var usuario = new Usuario
                {
                    idUsuario = 1,
                    nombre = "Juan",
                    apellido = "Pérez",
                    email = "juan@test.com"
                };

                var ruta = new Ruta
                {
                    idRuta = 5,
                    nombre = "Ruta Montaña"
                };

                var valoracion = new Valoracion
                {
                    id = 100,
                    dificultad = 4,
                    belleza = 5,
                    interesCultural = 3,
                    fecha = new DateTime(2026, 2, 11),
                    usuario = usuario,
                    ruta = ruta
                };


                Assert.AreEqual(100, valoracion.id);
                Assert.AreEqual(4, valoracion.dificultad);
                Assert.AreEqual(5, valoracion.belleza);
                Assert.AreEqual(3, valoracion.interesCultural);
                Assert.AreEqual(new DateTime(2026, 2, 11), valoracion.fecha);

                Assert.IsNotNull(valoracion.usuario);
                Assert.AreEqual(1, valoracion.usuario.idUsuario);
                Assert.AreEqual("Juan", valoracion.usuario.nombre);

                Assert.IsNotNull(valoracion.ruta);
                Assert.AreEqual(5, valoracion.ruta.idRuta);
                Assert.AreEqual("Ruta Montaña", valoracion.ruta.nombre);
            }
        }




    }
}


