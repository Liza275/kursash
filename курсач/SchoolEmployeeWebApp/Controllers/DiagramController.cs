using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.BusinessLogic;
using SchoolBusinessLogic.ViewModel;

namespace SchoolEmployeeWebApp.Controllers
{
    public class DiagramController : Controller
    {
        private readonly LessonLogic lessonLogic;
        private readonly DiagramLogic diagramLogic;

        public DiagramController(LessonLogic lessonLogic, DiagramLogic diagramLogic)
        {
            this.lessonLogic = lessonLogic;
            this.diagramLogic = diagramLogic;
        }

        public IActionResult Index()
        {
            ViewBag.LessonsId = new SelectList(lessonLogic.Read(new LessonBindingModel { EmployeeId = Program.Employee.Id }), "Id", "LessonName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(DiagramBindingModel model)
        {
            model.DiagramsData = new DiagramViewModel[]
            {
                diagramLogic.GetDiagramByPayments(model),
                diagramLogic.GetDiagramByLessonsCount(model),
                diagramLogic.GetDiagramByLessonsPrice(model)
            };

            ViewBag.LessonsId = new SelectList(lessonLogic.Read(new LessonBindingModel { EmployeeId = Program.Employee.Id }), "Id", "LessonName");
            return View(model);
        }
    }
}
