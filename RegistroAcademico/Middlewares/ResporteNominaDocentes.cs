using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using PlayerUI.Model;

namespace PlayerUI.Middlewares
{
    class ResporteNominaDocentes
    {
        public string path;
        public void PrintReport(List<Usuario> lista)
        {
            //Fuentes y Colores
            Color blue = new DeviceRgb(0, 120, 212);
            Color gray = new DeviceRgb(217, 217, 217);
            PdfFont normal = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
            //Estilos
            Dictionary<int, Style> mainStyles = new Dictionary<int, Style>
             {
                 //TITULO CENTRADO
                 {100, new Style().SetBackgroundColor(ColorConstants.WHITE).SetBorder(Border.NO_BORDER).SetFontColor(ColorConstants.BLACK).SetFontSize(14).SetFont(normal).SetTextAlignment(TextAlignment.CENTER) },
                  //TEXTO NORMAL ALINEADO IZQUIERA FONDO GRIS
                {101, new Style().SetBackgroundColor(gray).SetBorder(Border.NO_BORDER).SetFontColor(ColorConstants.BLACK).SetFontSize(12).SetFont(normal).SetTextAlignment(TextAlignment.LEFT) },
                 //TEXTO NORMAL ALINEAMIENTO IZQUIERDA
                 {102, new Style().SetBackgroundColor(ColorConstants.WHITE).SetBorder(Border.NO_BORDER).SetFontColor(ColorConstants.BLACK).SetFontSize(12).SetFont(normal).SetTextAlignment(TextAlignment.LEFT) },
                //Fecha de impresion
                {103, new Style().SetBackgroundColor(ColorConstants.WHITE).SetBorder(Border.NO_BORDER).SetFontColor(ColorConstants.BLACK).SetFontSize(9).SetFont(normal).SetTextAlignment(TextAlignment.LEFT) },
                 //TEXTO DE ENCABEZADO DE COLUMNAS
                {105, new Style().SetBackgroundColor(blue).SetBorder(Border.NO_BORDER).SetFontColor(ColorConstants.WHITE).SetFontSize(12).SetFont(normal).SetTextAlignment(TextAlignment.LEFT) },

             };
            string fecha = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            var exportFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = System.IO.Path.Combine(exportFolder, $"Nomina Docentes ({fecha}).pdf");
            using (var writer = new PdfWriter(path))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    var doc = new Document(pdf, PageSize.A4.Rotate());
                    doc.SetMargins(35, 35, 35, 35);

                    Table tabla = new Table(new float[6]).UseAllAvailableWidth();
                    Cell contenido;

                    //Titulo
                    contenido = new Cell(1, 6).Add(new Paragraph("Nómina de Alumnos")).AddStyle(mainStyles[100]);
                    tabla.AddCell(contenido);

                    //Espacio en blanco
                    contenido = new Cell(1, 6).Add(new Paragraph("\n ")).AddStyle(mainStyles[102]);
                    tabla.AddCell(contenido);

                    //Encabezados
                    contenido = new Cell(1, 1).Add(new Paragraph("Documento")).AddStyle(mainStyles[105]);
                    tabla.AddCell(contenido);
                    contenido = new Cell(1, 1).Add(new Paragraph("Nombre")).AddStyle(mainStyles[105]);
                    tabla.AddCell(contenido);
                    contenido = new Cell(1, 1).Add(new Paragraph("Apellido")).AddStyle(mainStyles[105]);
                    tabla.AddCell(contenido);
                    contenido = new Cell(1, 1).Add(new Paragraph("Telefono")).AddStyle(mainStyles[105]);
                    tabla.AddCell(contenido);
                    contenido = new Cell(1, 1).Add(new Paragraph("Dirección")).AddStyle(mainStyles[105]);
                    tabla.AddCell(contenido);
                    contenido = new Cell(1, 1).Add(new Paragraph("Fecha de Nacimiento")).AddStyle(mainStyles[105]);
                    tabla.AddCell(contenido);

                    for (int i = 0; i < lista.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            contenido = new Cell(1, 1).Add(new Paragraph(lista[i].Documento)).AddStyle(mainStyles[102]);
                            tabla.AddCell(contenido);
                            contenido = new Cell(1, 1).Add(new Paragraph(lista[i].Nombre)).AddStyle(mainStyles[102]);
                            tabla.AddCell(contenido);
                            contenido = new Cell(1, 1).Add(new Paragraph(lista[i].Apellido)).AddStyle(mainStyles[102]);
                            tabla.AddCell(contenido);
                            contenido = new Cell(1, 1).Add(new Paragraph(lista[i].Telefono)).AddStyle(mainStyles[102]);
                            tabla.AddCell(contenido);
                            contenido = new Cell(1, 1).Add(new Paragraph(lista[i].Direccion)).AddStyle(mainStyles[102]);
                            tabla.AddCell(contenido);
                            contenido = new Cell(1, 1).Add(new Paragraph(lista[i].Fecha_Nacimiento.ToString())).AddStyle(mainStyles[102]);
                            tabla.AddCell(contenido);
                          
                        }
                        else
                        {
                            contenido = new Cell(1, 1).Add(new Paragraph(lista[i].Documento)).AddStyle(mainStyles[101]);
                            tabla.AddCell(contenido);
                            contenido = new Cell(1, 1).Add(new Paragraph(lista[i].Nombre)).AddStyle(mainStyles[101]);
                            tabla.AddCell(contenido);
                            contenido = new Cell(1, 1).Add(new Paragraph(lista[i].Apellido)).AddStyle(mainStyles[101]);
                            tabla.AddCell(contenido);
                            contenido = new Cell(1, 1).Add(new Paragraph($"{lista[i].IdAula}")).AddStyle(mainStyles[101]);
                            tabla.AddCell(contenido);
                            contenido = new Cell(1, 1).Add(new Paragraph(lista[i].Telefono)).AddStyle(mainStyles[101]);
                            tabla.AddCell(contenido);
                            contenido = new Cell(1, 1).Add(new Paragraph(lista[i].Direccion)).AddStyle(mainStyles[101]);
                            tabla.AddCell(contenido);
                            contenido = new Cell(1, 1).Add(new Paragraph(lista[i].Fecha_Nacimiento.ToString())).AddStyle(mainStyles[101]);
                            tabla.AddCell(contenido);
                            
                        }
                    }

                    //espacios
                    contenido = new Cell(2, 6).Add(new Paragraph("\n ")).AddStyle(mainStyles[100]);
                    tabla.AddCell(contenido);

                    //pie de página
                    contenido = new Cell(1, 6).Add(new Paragraph("Fecha de impresión: " + DateTime.Now.ToString())).AddStyle(mainStyles[103]);
                    tabla.AddCell(contenido);
                    doc.Add(tabla);
                    doc.Close();
                }
            }
        }
    }
}
