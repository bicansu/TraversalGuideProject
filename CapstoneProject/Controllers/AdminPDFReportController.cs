using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace CapstoneProject.Controllers
{
    public class AdminPDFReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            Paragraph paragraph = new Paragraph("Traversal Capstone Pdf Raporu");

            document.Add(paragraph);
            document.Close();
            return File("/pdfreports/dosya1.pdf", "application/pdf","dosya1.pdf");

        }
        public IActionResult StaticTravelAgencyReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfTable = new PdfPTable(1);

            pdfTable.AddCell("Acente Adı");


            pdfTable.AddCell("Antalya Turu");
            pdfTable.AddCell("Almanya Turu");
            pdfTable.AddCell("Amerika Turu");

            document.Add(pdfTable);


            document.Close();
            return File("/pdfreports/dosya1.pdf", "application/pdf", "dosya1.pdf");

        }
    }
}
