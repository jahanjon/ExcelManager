using ClosedXML.Excel;
using Domain.Entities;
using Domain.Interface;
using Domain.Persistence;
using ExcelManager.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace ExcelManager.Controllers
{
    public class ReportSheetController : Controller
    {
        private readonly IExcelService excelService;
        private readonly ExcelManagerDBContext excelManagerDBContext;

        public ReportSheetController(IExcelService excelService, ExcelManagerDBContext excelManagerDBContext)
        {
            this.excelService = excelService;
            this.excelManagerDBContext = excelManagerDBContext;
        }

        [HttpPost]
        public async Task<IActionResult> UploadExcel(IFormFile excelFile)
        {
            if (excelFile == null || excelFile.Length == 0 ||
    !(Path.GetExtension(excelFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase) ||
      Path.GetExtension(excelFile.FileName).Equals(".xls", StringComparison.OrdinalIgnoreCase)))
            {
                ModelState.AddModelError("FileError", "فقط فایل‌های اکسل با فرمت .xlsx یا .xls مجاز هستند.");
                return View();
            }



            using (var stream = new MemoryStream())
            {
                await excelFile.CopyToAsync(stream);
                var result = await excelService.ProcessExcelFileAsync(stream);

                if (result)
                {
                    ViewBag.Message = "فایل با موفقیت پردازش شد.";
                }
                else
                {
                    ViewBag.Message = "خطا در پردازش فایل.";
                }
            }

            return View();
        }
       
    }
}
