using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.Interface;
using SchoolBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;

namespace SchoolBusinessLogic.BusinessLogic
{
    public class EmployeeLogic
    {
        private readonly IEmployeeStorage _employeeStorage;

        public EmployeeLogic(IEmployeeStorage employeeStorage)
        {
            _employeeStorage = employeeStorage;
        }

        public List<EmployeeViewModel> Read(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return _employeeStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<EmployeeViewModel> { _employeeStorage.GetElement(model) };
            }
            return _employeeStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(EmployeeBindingModel model)
        {
            var employee = _employeeStorage.GetElement(new EmployeeBindingModel
            {
                Login = model.Login
            });
            if (employee != null && employee.Id != model.Id)
            {
                throw new Exception("Уже есть работник с таким логином");
            }
            if (model.Id.HasValue)
            {
                _employeeStorage.Update(model);
            }
            else
            {
                _employeeStorage.Insert(model);
            }
        }

        public void Delete(EmployeeBindingModel model)
        {
            var employee = _employeeStorage.GetElement(new EmployeeBindingModel
            {
                Id = model.Id
            });
            if (employee == null)
            {
                throw new Exception("Работник не найден");
            }
            _employeeStorage.Delete(model);
        }

        public EmployeeViewModel Login(EmployeeBindingModel model)
        {
            var employee = _employeeStorage.GetElement(
                new EmployeeBindingModel
                {
                    Login = model.Login
                });

            if (employee == null || !employee.Password.Equals(model.Password))
            {
                throw new Exception("Работник не найден");
            }
            return employee;
        }
    }
}
