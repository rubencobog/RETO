using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RetaCantabria
{
    public partial class EnviarGPX : Form
    {
        private MemoryStream archivoGPX;
        private string nombreArchivo;
        private string textoporDefecto;
        private string rutaArchivo;
        private string contenido;
        public EnviarGPX()
        {
            InitializeComponent();
            textoporDefecto = """
                <?xml version="1.0" encoding="utf-8"?>
                <gpx version="1.1" creator="ProyectoSpringBoot"
                     xmlns="http://www.topografix.com/GPX/1/1"
                     xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                     xsi:schemaLocation="http://www.topografix.com/GPX/1/1 
                                         http://www.topografix.com/GPX/1/1/gpx.xsd">

                    <!-- Información generica de la ruta y usuario -->
                    <metadata>
                		<tipoRegistro>InfoGeneral</tipoRegistro>
                		<nombreRuta>Ruta de Montaña Ejemplo</nombreRuta>
                		<enlaceWikiloc>www.rutas.es</enlaceWikiloc>
                        <author>prueba1@gmail.com</author>
                		<fechaCreacionGPX>2026-01-29 14:30:00</fechaCreacionGPX>
                    </metadata>
                    <!-- Creación de puntos Trackpoint y Waypoint generica
                    (Puedes crear los que quieras debajo de este)
                    (Pueden tener cualquier orden que queras)
                    -->
                    <!-- Waypoint generico(Introduce tus datos) -->
                	<wpt latitud="40.417000" longitud="-3.704200" elevacion="15">
                		<timeestamp>2026-01-29 14:30:00</timeestamp>
                		<nombre>1</nombre>
                		<descripcion>No</descripcion>
                	</wpt>
                    <!-- Trackpoint generico(Introduce tus datos) -->
                	<trk latitud="40.417000" longitud="-3.704200" elevacion="15">
                		<timeestamp>2026-01-29 14:30:00</timeestamp>
                	</trk>
                </gpx>
                """;
            contenido = textoporDefecto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de texto y GPX|*.txt;*.gpx";
            openFileDialog.Title = "Seleccionar archivo";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo = openFileDialog.FileName;
                nombreArchivo = Path.GetFileName(rutaArchivo);
                contenido = System.IO.File.ReadAllText(rutaArchivo);
                textBox1.Text = contenido;
                byte[] bytes = File.ReadAllBytes(rutaArchivo);
                archivoGPX = new MemoryStream(bytes);
                MessageBox.Show($"Archivo cargado correctamente. Tamaño: {archivoGPX.Length} bytes");
            }
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            contenido = textBox1.Text;
            if (esValido())
            {
              try
                {
                    using var cliente = new HttpClient();
                    var respuesta = await cliente.GetAsync("http://192.168.6.1:5050/actuator/health");
                    var texto = await respuesta.Content.ReadAsStringAsync();
                    MessageBox.Show("Conectado correctamente al servidor: " + texto, "Conexión OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión con Spring Boot: " + ex.Message, "Conexión fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textoporDefecto == textBox1.Text)
                {
                    MessageBox.Show("El archivo GPX ha no sido modificado. Por favor, modifique o sube uno nuevo", "Archivo modificado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            if (rutaArchivo==null && textoporDefecto!=textBox1.Text)
            {
                    DialogResult resultado = MessageBox.Show("Desea subir este archivo y guardarlo en la carpeta GPXFiles en tu proyecto","Éxito",
                    MessageBoxButtons.YesNo,  MessageBoxIcon.Information);
                    if (resultado == DialogResult.Yes)
                    {
                     crearArchivodesde0();
                    }
                    return;
            }
            if(rutaArchivo!=null) {
                await EnviarArchivo();
             }
            }
            else { 
                MessageBox.Show("El archivo GPX no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            limpiar();
        }
        public bool esValido()
        {
            bool tipoRegistro = false;
            bool nombreRuta = false;
            bool enlaceWikiloc = false;
            bool author = false;
            bool fechaCreacion = false;
            using (StringReader reader = new StringReader(contenido))
            {
                string linea;
                bool dentroMetadata = false;
                while ((linea = reader.ReadLine()) != null)
                {
                    linea=linea.Trim();
                    if (linea.Contains("<metadata>"))
                    {
                       dentroMetadata = true;
                        continue;
                    }
                    if (linea.Contains("</metadata>"))
                    {
                       break;
                    }
                    if (dentroMetadata)
                    {
                        if (linea.Contains("<tipoRegistro>InfoGeneral</tipoRegistro>"))
                            tipoRegistro = true;
                        else if (linea.Contains("<nombreRuta>") && linea.Contains("</nombreRuta>"))
                            nombreRuta = true;
                        else if (linea.Contains("<enlaceWikiloc>") && linea.Contains("</enlaceWikiloc>"))
                            enlaceWikiloc = true;
                        else if (linea.Contains("<author>") && linea.Contains("</author>"))
                            author = true;
                        else if (linea.Contains("<fechaCreacionGPX>") && linea.Contains("</fechaCreacionGPX>"))
                            fechaCreacion = true;
                    }
                }
            }
            return tipoRegistro && nombreRuta && enlaceWikiloc && author && fechaCreacion; ;
        }
        public void crearArchivodesde0()
        {
            string rutaProyecto = Directory.GetCurrentDirectory();
            string rutaCarpeta = Path.Combine(rutaProyecto, "GPXFiles");

            if (!Directory.Exists(rutaCarpeta))
                Directory.CreateDirectory(rutaCarpeta);

            int cont = 0;
            string nombre = "generico.gpx";
            rutaArchivo = Path.Combine(rutaCarpeta, nombre);

            while (File.Exists(rutaArchivo))
            {
                cont++;
                nombre = $"generico{cont}.gpx";
                rutaArchivo = Path.Combine(rutaCarpeta, nombre);
            }
            File.WriteAllText(rutaArchivo, textBox1.Text);

            nombreArchivo = Path.GetFileName(rutaArchivo);
            archivoGPX = new MemoryStream(File.ReadAllBytes(rutaArchivo));
        }
        public void guardarDatos()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de texto y GPX|*.txt;*.gpx";
            openFileDialog.Title = "Seleccionar archivo";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo = openFileDialog.FileName;
                nombreArchivo = Path.GetFileName(rutaArchivo);
                contenido = System.IO.File.ReadAllText(rutaArchivo);
                textBox1.Text = contenido;
                byte[] bytes = File.ReadAllBytes(rutaArchivo);
                archivoGPX = new MemoryStream(bytes);
                MessageBox.Show($"Archivo cargado correctamente. Tamaño: {archivoGPX.Length} bytes");
            }
        }
        async Task EnviarArchivo()
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    using (var contenido = new MultipartFormDataContent())
                    {
                        archivoGPX.Position = 0;
                        var archivoContenido = new StreamContent(archivoGPX);
                        archivoContenido.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/gpx+xml");
                        contenido.Add(archivoContenido, "file", nombreArchivo);
                        var respuesta = await cliente.PostAsync("http://192.168.6.1:5050/gpx/upload", contenido);
                        if (respuesta.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Archivo GPX enviado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al enviar el archivo GPX", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el archivo GPX", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void limpiar()
        {
            rutaArchivo = null;
            contenido = null;
            nombreArchivo = null;
            archivoGPX = null;
            textBox1.Text = textoporDefecto;
        }
        private void EnviarGPX_Load(object sender, EventArgs e)
        {
            textBox1.Text = textoporDefecto;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textoporDefecto;
            textBox1.BackColor = Color.White;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textoporDefecto != textBox1.Text)
            {
                textBox1.BackColor = Color.Yellow;
            }
            else
            {
                textBox1.BackColor = Color.White;
            }
        }
    }
}
