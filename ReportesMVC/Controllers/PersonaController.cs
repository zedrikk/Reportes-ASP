using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using ReportesMVC.Models;

namespace ReportesMVC.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string generarReporte()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage ep = new ExcelPackage();
                ep.Workbook.Worksheets.Add("Hoja de Prueba");
                ExcelWorksheet ew1 = ep.Workbook.Worksheets[0];
                ep.SaveAs(ms);
                byte[] buffer = ms.ToArray();
                return Convert.ToBase64String(buffer);
            }
        }
        public List<Persona> listaPersonas()
        {
            BDReportesContext bDReportesContext = new BDReportesContext();
            return bDReportesContext.Personas.ToList();
        }
    }
}
