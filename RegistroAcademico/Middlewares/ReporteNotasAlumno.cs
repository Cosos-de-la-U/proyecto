using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI.Middlewares
{
    class ReporteNotasAlumno
    {
        public string path;
        public void PrintReport(List<String> lista)
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
            var exportFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = System.IO.Path.Combine(exportFolder, "Notas(" + "asdf" + ").pdf");
            using (var writer = new PdfWriter(path))
            {
                using (var pdf = new PdfDocument(writer))
                {

                }
            }
        }
    }
}
