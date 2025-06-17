using ClienteConsultasMedicas.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;

namespace ClienteConsultasMedicas.Utils
{
    public static class PDFHelper
    {
        public static bool ExportarHistorial(List<ConsultaHistorial> historial, string nombrePaciente)
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = $"Historial_{nombrePaciente.Replace(" ", "_")}_{DateTime.Now:yyyyMMddHHmm}.pdf";
                string fullPath = Path.Combine(desktopPath, fileName);

                using FileStream stream = new FileStream(fullPath, FileMode.Create);
                Document doc = new Document(PageSize.A4, 20, 20, 20, 20);
                PdfWriter.GetInstance(doc, stream);

                doc.Open();

                // Encabezado
                string nombreMedico = TokenHelper.GetNombre() ?? "Médico Desconocido";
                var encabezado = new Paragraph($"Historial Clínico del Paciente\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16));
                encabezado.Alignment = Element.ALIGN_CENTER;
                doc.Add(encabezado);

                // Información del médico y fecha
                var info = new Paragraph($"Generado por: Dr. {nombreMedico}\nFecha: {DateTime.Now:dd/MM/yyyy HH:mm}\n\n", FontFactory.GetFont(FontFactory.HELVETICA, 11));
                info.Alignment = Element.ALIGN_RIGHT;
                doc.Add(info);

                // Título
                var titulo = new Paragraph($"Historial Clínico de {nombrePaciente}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16));
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);
                doc.Add(new Paragraph(" ")); // espacio

                // Tabla
                PdfPTable tabla = new PdfPTable(4);
                tabla.WidthPercentage = 100;
                tabla.SetWidths(new float[] { 2f, 3f, 3f, 3f });

                // Encabezados
                string[] headers = { "Fecha", "Síntomas", "Diagnóstico", "Tratamiento" };
                foreach (var h in headers)
                {
                    var cell = new PdfPCell(new Phrase(h, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                    cell.BackgroundColor = new BaseColor(240, 240, 240);
                    tabla.AddCell(cell);
                }

                // Filas
                foreach (var c in historial)
                {
                    tabla.AddCell(c.fechaHora.ToString("dd/MM/yyyy HH:mm"));
                    tabla.AddCell(c.sintomas);
                    tabla.AddCell(c.diagnostico);
                    tabla.AddCell(c.tratamiento);
                }

                doc.Add(tabla);
                doc.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
