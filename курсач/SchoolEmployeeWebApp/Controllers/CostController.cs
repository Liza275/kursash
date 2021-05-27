using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.BusinessLogic;
using System.Linq;

namespace SchoolEmployeeWebApp.Controllers
{
    public class CostController : Controller
    {
        private readonly CostLogic costLogic;
        private readonly SocietyLogic societyLogic;

        public CostController(CostLogic costLogic, SocietyLogic societyLogic)
        {
            this.costLogic = costLogic;
            this.societyLogic = societyLogic;
        }

        public ActionResult Index()
        {
            var costs = costLogic.Read(new CostBindingModel
            {
                EmployeeId = Program.Employee.Id
            });
            return View(costs);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cost = costLogic.Read(new CostBindingModel
            {
                Id = id,
                EmployeeId = Program.Employee.Id
            }).FirstOrDefault();

            if (cost == null)
            {
                return NotFound();
            }

            return View(cost);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CostBindingModel model)
        {
            if (ModelState.IsValid)
            {
                model.EmployeeId = Program.Employee.Id;
                costLogic.CreateOrUpdate(model);
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

            var cost = costLogic.Read(new CostBindingModel
            {
                Id = id,
                EmployeeId = Program.Employee.Id
            }).FirstOrDefault();

            if (cost == null)
            {
                return NotFound();
            }

            return View(new CostBindingModel
            {
                Id = cost.Id,
                Description = cost.Description,
                Sum = cost.Sum,
                EmployeeId = cost.EmployeeId
            });
        }

        // POST: CostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, CostBindingModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                costLogic.CreateOrUpdate(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: CostController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cost = costLogic.Read(new CostBindingModel
            {
                Id = id,
                EmployeeId = Program.Employee.Id
            }).FirstOrDefault();

            if (cost == null)
            {
                return NotFound();
            }

            return View(cost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            costLogic.Delete(new CostBindingModel { Id = id, EmployeeId = Program.Employee.Id });
            return RedirectToAction(nameof(Index));
        }

        public ActionResult BindToSociety()
        {
            ViewBag.CostsId = new SelectList(costLogic.Read(new CostBindingModel { EmployeeId = Program.Employee.Id }), "Id", "Description");
            ViewBag.SocietiesId = new SelectList(societyLogic.Read(null), "Id", "SocietyName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BindToSociety(BindCostToSocietyBindingModel model)
        {
            if (ModelState.IsValid)
            {
                costLogic.BindToSociety(model);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CostsId = new SelectList(costLogic.Read(new CostBindingModel { EmployeeId = Program.Employee.Id }), "Id", "Description");
            ViewBag.SocietiesId = new SelectList(societyLogic.Read(null), "Id", "SocietyName");
            return View(model);
        }
    }
}
