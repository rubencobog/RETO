using iText.Barcodes;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Modelo;
using ModeloDTO;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using QRCoder;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;


namespace RetaCantabria
{
    public partial class Fichas : Form
    {
        private Ruta ruta;
        public Fichas(Ruta ruta)
        {
            InitializeComponent();
            this.ruta = ruta;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var cliente = new HttpClient();
            if (cbSeguridad.Checked||cbOrganizacion.Checked||cbUsuario.Checked)
            {
                string rutaProyecto = Directory.GetCurrentDirectory();
                string rutaCarpeta = Path.Combine(rutaProyecto, "PDFFiles");

                if (!Directory.Exists(rutaCarpeta))
                    Directory.CreateDirectory(rutaCarpeta);
                
                string nombreCarpeta = validaNombreRuta(ruta.nombre);
                string rutaPDFs = Path.Combine(rutaCarpeta, nombreCarpeta);

                if (!Directory.Exists(rutaPDFs))
                    Directory.CreateDirectory(rutaPDFs);

                if (cbSeguridad.Checked)
                {
                   await FichaSeguridad(cliente,rutaPDFs);
                }
                if (cbUsuario.Checked)
                {
                   await FichaUsuario(cliente,rutaPDFs);
                }
                if (cbOrganizacion.Checked)
                {
                    await FichaOrganizacion(cliente,rutaPDFs);
                }
            }
        }
        public async Task FichaSeguridad(HttpClient httpClient,string rutaCarpeta)
        {
            long idRuta = ruta.idRuta;
            List<PuntoPeligro> puntosPeligro=await httpClient.GetFromJsonAsync<List<PuntoPeligro>>($"http://192.168.6.1:5050/api/puntopeligro/buscaPP?idRuta={idRuta}");
            if (puntosPeligro.Count!=0)
            {
              MessageBox.Show("Puntos de peligro encontrados: " + puntosPeligro.Count);
              crearFichaSeguridad(puntosPeligro, rutaCarpeta,httpClient);
            }
            else
            {
             MessageBox.Show("No se han encontrado puntos de peligro para esta ruta, no se ha generado la ficha de seguridad");
            }
               
            MessageBox.Show("PDF generado en: " + rutaCarpeta);
        }
        public async void crearFichaSeguridad(List<PuntoPeligro>puntos,string rutaPdf, HttpClient httpClient)
        {
            int maximoGavedad = puntos.Max(p => p.gravedad);
            // ---------- 1. CREAR GRÁFICO (PNG) ---------- 
            string rutaImagen = Path.Combine(Path.GetTempPath(), "grafico.png");
            var model = new PlotModel
            {
                Title = "Gravedad por kilómetro"
            };
            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Kilómetro"
            });
            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Gravedad",
                Minimum = 0,
                Maximum = maximoGavedad + 2
            });
            var serie = new LineSeries
            {
                MarkerType = MarkerType.Circle
            };
            foreach (var p in puntos)
            {
                serie.Points.Add(new DataPoint(p.kilometro, p.gravedad));
            }
            model.Series.Add(serie);
            using (var stream = File.Create(rutaImagen))
            {
                var exporter = new PngExporter
                {
                    Width = 600,
                    Height = 400
                };
                exporter.Export(model, stream);
            }
            // ---------- 2. CREAR PDF ---------- 
            PdfWriter writer = new PdfWriter(rutaPdf+"/Seguridad.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            document.Add(new Paragraph("Ficha Seguridad")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(18));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph(ruta.nombre)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(16));
            document.Add(new Paragraph("Puntos de peligro encontrados: " + puntos.Count)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(12));
            document.Add(new Paragraph("\n"));
            Table table = new Table(UnitValue.CreatePercentArray(new float[] { 10, 20, 15, 55 }))
                .UseAllAvailableWidth();
            table.AddHeaderCell("ID");
            table.AddHeaderCell("Kilómetro");
            table.AddHeaderCell("Gravedad");
            table.AddHeaderCell("Justificación");
            foreach (var p in puntos)
            {
                table.AddCell(p.id.ToString());
                table.AddCell(p.kilometro.ToString("0.00"));
                table.AddCell(p.gravedad.ToString());
                table.AddCell(p.justificacion);
            }
            document.Add(table);
            // ---------- 3. AÑADIR IMAGEN AL PDF ---------- 
            document.Add(new Paragraph("\n"));
            ImageData imgData = ImageDataFactory.Create(rutaImagen);
            iText.Layout.Element.Image img =
                new iText.Layout.Element.Image(imgData)
                .SetAutoScale(true)
                .SetTextAlignment(TextAlignment.CENTER);
            document.Add(img);
            document.Add(new Paragraph("\n"));
            int gravedadTotal = puntos.Sum(p => p.gravedad);
            int cantidadPuntos = puntos.Count;
            document.Add(new Paragraph("La media de dificultad de la ruta es: " + (gravedadTotal / cantidadPuntos)));
            document.Close();

            var rutaQR = await subirQR(rutaPdf + "/Seguridad.pdf", httpClient);
            if (string.IsNullOrEmpty(rutaQR))
            {
                MessageBox.Show("La URL recibida es null o vacía. Revisa el método subirQR.");
                return;
            }
            using (QRCodeGenerator qr = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qr.CreateQrCode(rutaQR, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                pb_Seguridad.Image = qrCodeImage;
                pb_Seguridad.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        public async Task<string> subirQR(string rutaPdf,HttpClient cliente){
            var fileBytes =File.ReadAllBytes(rutaPdf);
            var content = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(fileBytes);
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
            content.Add(fileContent, "file", Path.GetFileName(rutaPdf));
            var response = await cliente.PostAsync("http://192.168.6.1:5050/api/pdf",content);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Error subiendo PDF: " + response.StatusCode);

            var json =await response.Content.ReadAsStringAsync();
            Console.WriteLine("Respuesta JSON: " + json);
            dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            string url = result?.url;
            if (string.IsNullOrEmpty(url))
                throw new Exception("No se recibió URL válida de la API");

            return url;
        }
        public async Task FichaUsuario(HttpClient httpClient, string rutaCarpeta)
        {
            long idRuta = ruta.idRuta;
            List<PuntoRutaDTO> puntos = await new HttpClient().GetFromJsonAsync<List<PuntoRutaDTO>>($"http://192.168.6.1:5050/api/puntoruta/rutaPR?idRuta={idRuta}");
            if (puntos.Count != 0)
            {
                MessageBox.Show("Puntos de peligro encontrados: " + puntos.Count);
                crearFichaUsuario(puntos, rutaCarpeta,httpClient);
            }
            else
            {
                MessageBox.Show("No se han encontrado puntos de peligro para esta ruta, no se ha generado la ficha de seguridad");
            }

            MessageBox.Show("PDF generado en: " + rutaCarpeta);
        }
        public async  void crearFichaUsuario(List<PuntoRutaDTO> puntos,string rutaPdf,HttpClient httpClient)
        {
            // ---------- 1. CREAR "Mapa" (PNG) ---------- 
            var plotModel = new PlotModel
            {
                Title = "Recorrido de la ruta"
            };
            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Longitud",
                MaximumPadding=0.1,
                MinimumPadding=0.1
            });
            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Latitud",
                MaximumPadding = 0.1,
                MinimumPadding = 0.1
            });
            var lineSeries = new LineSeries
            {
                Color = OxyColors.Blue,
                MarkerType = MarkerType.Circle,
                MarkerFill = OxyColors.Blue,
                MarkerSize = 2
            };
            int cont = 1;
            foreach (PuntoRutaDTO punto in puntos)
            {
              lineSeries.Points.Add(new DataPoint(punto.longitud.GetValueOrDefault(), punto.latitud.GetValueOrDefault()));
                plotModel.Annotations.Add(new OxyPlot.Annotations.TextAnnotation
                {
                    Text = $"{cont}:{punto.elevacion}m",
                    TextPosition = new DataPoint(punto.longitud.GetValueOrDefault(), punto.latitud.GetValueOrDefault()),
                    Stroke = OxyColors.Transparent,
                    TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Left,
                    TextVerticalAlignment = OxyPlot.VerticalAlignment.Top
                });
                cont++;
            }
            plotModel.Series.Add(lineSeries);
            byte[] imagenBytes;
            using (var ms=new MemoryStream())
            {
                var pngExporter= new PngExporter
                {
                    Width = 700,
                    Height = 500
                };
                pngExporter.Export(plotModel, ms);
                imagenBytes = ms.ToArray();
            }
                // ---------- 2. CREAR PDF ---------- 
            PdfWriter writer = new PdfWriter(rutaPdf + "/Usuario.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            
            document.Add(new Paragraph("Ficha Usuario")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(18));
            document.Add(new Paragraph("\n"));

            document.Add(new Paragraph("Nombre de la ruta: "+ruta.nombre));
            document.Add(new Paragraph("Cantidad de puntos de la ruta: " + puntos.Count)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(12));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph($"Duración de la ruta: {ruta.duracion}"));
            document.Add(new Paragraph($"Distancia de la ruta: {ruta.distancia} km"));
            document.Add(new Paragraph($"Descripción de la ruta: {ruta.indicaciones}"));
            document.Add(new Paragraph($"Altura máxima: {ruta.altitudMax}"));
            document.Add(new Paragraph($"Altura mínima: {ruta.altitudMin}"));
            document.Add(new Paragraph($"Recomendaciones: {ruta.recomendacionesEquipo}"));

            iText.Layout.Element.Image img=new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(imagenBytes));
            img.SetMaxWidth(500);
            img.SetMaxHeight(400);
            img.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            document.Add(img);
            document.Close();

            var rutaQRs = await subirQR(rutaPdf + "/Usuario.pdf", httpClient);
            if (string.IsNullOrEmpty(rutaQRs))
            {
                MessageBox.Show("La URL recibida es null o vacía. Revisa el método subirQR.");
                return;
            }
            using (QRCodeGenerator qr = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qr.CreateQrCode(rutaQRs, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                pb_Usuario.Image = qrCodeImage;
                pb_Usuario.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        public async Task FichaOrganizacion(HttpClient httpClient, string rutaCarpeta)
        {
            crearFichaOrganizacion(rutaCarpeta,httpClient);
            MessageBox.Show("PDF generado en: " + rutaCarpeta);
        }
        public async void crearFichaOrganizacion(string rutaPdf,HttpClient httpClient)
        {
            PdfWriter writer = new PdfWriter(rutaPdf + "/Organizacion.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            document.Add(new Paragraph("Ficha Organización")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(18));
            string rutaGenerica = AppDomain.CurrentDomain.BaseDirectory;
            string rutaImagenDificultad = null;
            
            if (ruta.nivelRiesgo<=2)
            {
                rutaImagenDificultad = Path.Combine(rutaGenerica, "Resources", "1.jpg");
            }
            else if (ruta.nivelRiesgo==3)
            {
                rutaImagenDificultad = Path.Combine(rutaGenerica, "Resources", "2.jpg");
            }
            else
            {
                rutaImagenDificultad = Path.Combine(rutaGenerica, "Resources", "3.jpg");
            }
            if (!File.Exists(rutaImagenDificultad))
            {
                throw new FileNotFoundException("No se encontró la imagen: " + rutaImagenDificultad);
            }
            if (rutaImagenDificultad!=null)
            {
            var imagenDificultad= new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(rutaImagenDificultad));
            imagenDificultad.SetMaxWidth(150);
            imagenDificultad.SetMaxHeight(150);
            imagenDificultad.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            document.Add(imagenDificultad);
            }
            
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("Nombre de la ruta: " + ruta.nombre));
            document.Add(new Paragraph($"Duración de la ruta: {ruta.duracion}"));
            document.Add(new Paragraph($"Distancia de la ruta: {ruta.distancia} km"));
            document.Add(new Paragraph($"Estado de la ruta: {ruta.estadoRuta}"));
            document.Add(new Paragraph($"Nivel de accesibilidad: {ruta.accesibilidad}"));
            document.Add(new Paragraph($"Altura máxima: {ruta.altitudMax}"));
            document.Add(new Paragraph($"Altura mínima: {ruta.altitudMin}"));
            document.Add(new Paragraph($"Temporadas recomendadas para la ruta: {ruta.temporadas}"));
            document.Add(new Paragraph($"Nivel de esfuerzo: {ruta.nivelEsfuerzo}"));
            document.Add(new Paragraph($"Nivel de riesgo: {ruta.nivelRiesgo}"));
            document.Add(new Paragraph($"Tipo de terreno: {ruta.tipoTerreno}"));
            document.Add(new Paragraph($"Desnivel positivo: {ruta.desnivelPositivo} m"));
            document.Add(new Paragraph($"Desnivel negativo: {ruta.desnivelNegativo} m"));
            document.Add(new Paragraph($"Desnivel acumulado: {ruta.desnivelAcumulado} m"));
            document.Add(new Paragraph($"Tipo recorrido de la ruta: {ruta.clasificacion}"));
            document.Add(new Paragraph($"Ruta familiar: {ruta.rutaFamiliar}"));
            document.Add(new Paragraph($"Zona Geográfica: {ruta.zonaGeografica}"));
            document.Add(new Paragraph($"Indicaciones de la ruta: {ruta.indicaciones}"));
            document.Add(new Paragraph($"Recomendaciones: {ruta.recomendacionesEquipo}"));
            document.Close();
            var rutaQR = await subirQR(rutaPdf + "/Organizacion.pdf", httpClient);
            if (string.IsNullOrEmpty(rutaQR))
            {
                MessageBox.Show("La URL recibida es null o vacía. Revisa el método subirQR.");
                return;
            }
            using (QRCodeGenerator qr = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qr.CreateQrCode(rutaQR, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                pb_Organizacion.Image = qrCodeImage;
                pb_Organizacion.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        public string validaNombreRuta(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
              return "Ruta generica";
            }
                string caracteresInvalidos = @"\/:*?<>| ";
                char remplazo = '_';
                char[] resultado = nombre.ToCharArray();
                for (int i = 0; i < resultado.Length; i++)
                {
                    if (caracteresInvalidos.Contains(resultado[i]))
                    {
                        resultado[i] = remplazo;
                    }
                }
                return new string(resultado);
        }
    }
}

