using Microsoft.EntityFrameworkCore;
using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.Interface;
using SchoolBusinessLogic.ViewModel;
using SchoolDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolDAL.Implement
{
    public class CostStorage : ICostStorage
    {
        public static CostViewModel CreateViewModel(Cost cost)
        {
            return new CostViewModel
            {
                Id = cost.Id,
                Sum = cost.Sum,
                Description = cost.Description,
                Societies = cost.Societies?
                    .Select(rec => new Tuple<string, decimal>(rec.Society.SocietyName, rec.AdditionalCosts))
                    .ToList(),
                EmployeeId = cost.EmployeeId,
                EmployeeName = $"{cost.Employee.User.Surname} {cost.Employee.User.Name}"
            };
        }

        private Cost CreateModel(CostBindingModel model, Cost cost, SchoolDataBase context)
        {
            cost.Sum = model.Sum;
            cost.Description = model.Description;
            cost.EmployeeId = model.EmployeeId;

            if (model.SocietyId.HasValue && model.Id.HasValue)
            {
                var society = context.Societies.FirstOrDefault(rec => rec.Id == model.SocietyId.Value);
                context.SocietyCosts.Add(new SocietyCost
                {
                    CostId = model.Id.Value,
                    SocietyId = society.Id,
                    AdditionalCosts = model.AdditionalCost.Value
                });
            }

            return cost;
        }

        public void Delete(CostBindingModel model)
        {
            using (var context = new SchoolDataBase())
            {
                var cost = context.Costs.FirstOrDefault(rec => rec.Id == model.Id);

                if (cost == null)
                {
                    throw new Exception("Затрата не найдена");
                }

                context.Costs.Remove(cost);
                context.SaveChanges();
            }
        }

        public CostViewModel GetElement(CostBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new SchoolDataBase())
            {
                var cost = context.Costs
                    .Include(rec => rec.Societies)
                    .ThenInclude(rec => rec.Society)
                    .ThenInclude(rec => rec.Client)
                    .ThenInclude(rec => rec.User)
                    .Include(rec => rec.Employee)
                    .ThenInclude(rec => rec.User)
                    .FirstOrDefault(rec => rec.Id == model.Id);

                return cost != null ? CreateViewModel(cost) : null;
            }
        }

        public List<CostViewModel> GetFilteredList(CostBindingModel model)
        {
            using (var context = new SchoolDataBase())
            {
                return context.Costs
                    .Include(rec => rec.Societies)
                    .ThenInclude(rec => rec.Society)
                    .ThenInclude(rec => rec.Client)
                    .ThenInclude(rec => rec.User)
                    .Include(rec => rec.Employee)
                    .ThenInclude(rec => rec.User)
                    .Select(CreateViewModel)
                    .ToList();
            }
        }

        public List<CostViewModel> GetFullList()
        {
            using (var context = new SchoolDataBase())
            {
                return context.Costs
                    .Include(rec => rec.Societies)
                    .ThenInclude(rec => rec.Society)
                    .ThenInclude(rec => rec.Client)
                    .ThenInclude(rec => rec.User)
                    .Include(rec => rec.Employee)
                    .ThenInclude(rec => rec.User)
                    .Select(CreateViewModel)
                    .ToList();
            }
        }

        public void Insert(CostBindingModel model)
        {
            using (var context = new SchoolDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Costs.Add(CreateModel(model, new Cost(), context));
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(CostBindingModel model)
        {
            using (var context = new SchoolDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var cost = context.Costs.FirstOrDefault(rec => rec.Id == model.Id);

                        if (cost == null)
                        {
                            throw new Exception("Затрата не найдена");
                        }

                        CreateModel(model, cost, context);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
