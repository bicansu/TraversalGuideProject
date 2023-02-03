using CapstoneProject.Models;
using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_DataAccessLayer.Concrete;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CapstoneProject.Controllers
{
    
    public class AdminExcelController : Controller
    {
        private readonly IExcelService _excelService;

        public AdminExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public IActionResult Index()
        {
           return View();
        }

        public List<AdminTravelAgencyModel> TravelAgencyList ()
        {
            List<AdminTravelAgencyModel> adminTravelAgencyModels = new List<AdminTravelAgencyModel>();
            using(var c = new Context())
            {
                adminTravelAgencyModels = c.TravelAgencys.Select(x => new AdminTravelAgencyModel
                {
                    Description = x.Description,
                    Image = x.Image
                }).ToList();
            }
            return adminTravelAgencyModels;
        }
        public IActionResult StaticExcelReport()
        {
            /* ExcelPackage excel = new ExcelPackage();
             var workSheet = excel.Workbook.Worksheets.Add("Sayfa1");
             workSheet.Cells[1, 1].Value = "Rota";
             workSheet.Cells[1, 2].Value = "Rehber";
             workSheet.Cells[1, 3].Value = "Kontenjan";

             workSheet.Cells[2, 1].Value = "Gürcitan Batum Turu";
             workSheet.Cells[2, 2].Value = "Kadir Yıldız";
             workSheet.Cells[2, 3].Value = "50";

             workSheet.Cells[3, 1].Value = "Sırbistan - Makedonya Turu";
             workSheet.Cells[3, 2].Value = "Zeyneğ Öztürk";
             workSheet.Cells[3, 3].Value = "35";

             var bytes = excel.GetAsByteArray();

             return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dosya.xlsx");*/
            return File(_excelService.ExcelList(TravelAgencyList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "YeniExcel.xlsx");
        }
        public IActionResult TravelAgencyExcelReport()
        {
            using(var workBook = new XLWorkbook())
            {
                var worksheet = workBook.Worksheets.Add("Tur Listesi");
                worksheet.Cell(1, 1).Value = "Açıklama";
                worksheet.Cell(1, 2).Value = "Görsel";


                int rowCount = 2;

                foreach(var item in TravelAgencyList())
                {
                    worksheet.Cell(rowCount, 1).Value = item.Description;
                    worksheet.Cell(rowCount, 2).Value = item.Image;
                    rowCount++;
                }

                using(var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");

                }

            }
        }
    }
}
