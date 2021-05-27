using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.BusinessLogic;
using System.Linq;

namespace SchoolEmployeeWebApp.Controllers
{
    public class LessonController : Controller
    {
        private LessonLogic lessonLogic;

        public LessonController(LessonLogic lessonLogic)
        {
            this.lessonLogic = lessonLogic;
        }

        public ActionResult Index()
        {
            var lessons = lessonLogic.Read(new LessonBindingModel
            {
                EmployeeId = Program.Employee.Id
            });
            return View(lessons);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = lessonLogic.Read(new LessonBindingModel
            {
                Id = id,
                EmployeeId = Program.Employee.Id
            }).FirstOrDefault();

            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LessonBindingModel model)
        {
            if (ModelState.IsValid)
            {
                model.EmployeeId = Program.Employee.Id;
                lessonLogic.CreateOrUpdate(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = lessonLogic.Read(new LessonBindingModel
            {
                Id = id,
                EmployeeId = Program.Employee.Id
            }).FirstOrDefault();

            if (lesson == null)
            {
                return NotFound();
            }

            return View(new LessonBindingModel
            {
                Id = lesson.Id,
                LessonName = lesson.LessonName,
                LessonCount = lesson.LessonCount,
                Price = lesson.Price,
                EmployeeId = lesson.EmployeeId
            });
        }

        // POST: LessonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, LessonBindingModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                lessonLogic.CreateOrUpdate(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: LessonController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = lessonLogic.Read(new LessonBindingModel
            {
                Id = id,
                EmployeeId = Program.Employee.Id
            }).FirstOrDefault();

            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: LessonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            lessonLogic.Delete(new LessonBindingModel { Id = id, EmployeeId = Program.Employee.Id });
            return RedirectToAction(nameof(Index));
        }
    }
}
