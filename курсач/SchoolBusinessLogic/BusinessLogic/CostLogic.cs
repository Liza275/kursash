using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.Interface;
using SchoolBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;

namespace SchoolBusinessLogic.BusinessLogic
{
    public class CostLogic
    {
        private readonly ICostStorage _costStorage;

        public CostLogic(ICostStorage costStorage)
        {
            _costStorage = costStorage;
        }

        public List<CostViewModel> Read(CostBindingModel model)
        {
            if (model == null)
            {
                return _costStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CostViewModel> { _costStorage.GetElement(model) };
            }
            return _costStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(CostBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _costStorage.Update(model);
            }
            else
            {
                _costStorage.Insert(model);
            }
        }

        public void Delete(CostBindingModel model)
        {
            var cost = _costStorage.GetElement(new CostBindingModel
            {
                Id = model.Id
            });
            if (cost == null)
            {
                throw new Exception("Затрата не найдена");
            }
            _costStorage.Delete(model);
        }

        public void BindToSociety(BindCostToSocietyBindingModel model)
        {
            var cost = _costStorage.GetElement(new CostBindingModel
            {
                Id = model.CostId
            });

            _costStorage.Update(new CostBindingModel
            {
                Id = cost.Id,
                Description = cost.Description,
                Sum = cost.Sum,
                AdditionalCost = model.AdditionalCost,
                SocietyId = model.SocietyId,
                EmployeeId = cost.EmployeeId
            });
        }
    }
}
