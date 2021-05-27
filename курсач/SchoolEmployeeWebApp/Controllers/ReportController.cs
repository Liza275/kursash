using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.BusinessLogic;
using SchoolBusinessLogic.HelperModel;
using System;
using System.IO;

namespace SchoolEmployeeWebApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment env;
        private readonly ReportLogic reportLogic;
        private readonly LessonLogic lessonLogic;

        public ReportController(IWebHostEnvironment env, ReportLogic reportLogic, LessonLogic lessonLogic)
        {
            this.env = env;
            this.reportLogic = reportLogic;
            this.lessonLogic = lessonLogic;
        }

        public IActionResult List()
        {
            ViewBag.LessonsId = new MultiSelectList(lessonLogic.Read(new LessonBindingModel { EmployeeId = Program.Employee.Id }), "Id", "LessonName");
            return View();
        }

        public IActionResult SaveToWord(ReportBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var fileName = "List.doc";
                model.EmployeeId = Program.Employee.Id;
                model.FileName = Path.Combine(env.WebRootPath, fileName);
                reportLogic.SaveSocietiesToWordFile(model);
                return PhysicalFile(model.FileName, "application/doc", fileName);
            }
            return View(model);
        }

        public IActionResult SaveToExcel(ReportBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var fileName = "List.xls";
                model.EmployeeId = Program.Employee.Id;
                model.FileName = Path.Combine(env.WebRootPath, fileName);
                reportLogic.SaveSocietiesToExcelFile(model);
                return PhysicalFile(model.FileName, "application/xls", fileName);
            }
            return View(model);
        }

        public IActionResult Report()
        {
            return View();
        }

        public IActionResult ShowReport(ReportBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var fileName = "Report.pdf";
                model.EmployeeId = Program.Employee.Id;
                model.FileName = Path.Combine(env.WebRootPath, fileName);
                reportLogic.SaveSocietiesToPdfFile(model);
                ViewBag.FilePath = $"../{fileName}?unique={DateTime.Now}";
                return View("Report");
            }
            return View("Report", model);
        }

        public IActionResult SendMail(ReportBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var fileName = "Report.pdf";
                model.EmployeeId = Program.Employee.Id;
                model.FileName = Path.Combine(env.WebRootPath, fileName);
                reportLogic.SaveSocietiesToPdfFile(model);
                MailLogic.MailSendAsync(new MailSendInfo
                {
                    MailAddress = Program.Employee.Login,
                    Subject = "Отчет по оплатам",
                    Text = "Ваш отчет",
                    ReportFile = model.FileName
                });
            }
            return View("Report", model);
        }
    }
}
