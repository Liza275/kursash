using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.BusinessLogic;
using SchoolEmployeeWebApp.Models;
using System.Diagnostics;

namespace SchoolEmployeeWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeLogic employeeLogic;

        public HomeController(EmployeeLogic employeeLogic)
        {
            this.employeeLogic = employeeLogic;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(EmployeeBindingModel model)
        {
            if (ModelState.IsValid)
            {
                Program.Employee = employeeLogic.Login(model);
                return RedirectToAction(nameof(Index), "Lesson");
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(EmployeeBindingModel model)
        {
            if (ModelState.IsValid)
            {
                employeeLogic.CreateOrUpdate(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
