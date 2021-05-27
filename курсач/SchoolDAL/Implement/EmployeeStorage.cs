using Microsoft.EntityFrameworkCore;
using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.Interface;
using SchoolBusinessLogic.ViewModel;
using SchoolDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolDAL.Implement
{
    public class EmployeeStorage : IEmployeeStorage
    {
        private Employee CreateModel(EmployeeBindingModel model, Employee Employee, SchoolDataBase schoolDataBase)
        {
            User user = new User
            {
                Name = model.EmployeeName,
                Surname = model.EmployeeSurname,
                Patronymic = model.EmployeePatronymic,
                DateBirth = model.DateBirth,
                Login = model.Login,
                Password = model.Password,
            };

            schoolDataBase.Users.Add(user);
            schoolDataBase.SaveChanges();
            Employee.UserId = user.Id;
            return Employee;
        }

        private EmployeeViewModel CreateViewModel(Employee Employee)
        {
            return new EmployeeViewModel
            {
                Id = Employee.Id,
               EmployeeName = Employee.User.Name,
               EmployeeSurname = Employee.User.Surname,
               EmployeePatronymic = Employee.User.Patronymic,
               DateBirth = Employee.User.DateBirth,
                Login = Employee.User.Login,
                Password = Employee.User.Password
            };
        }

        public List<EmployeeViewModel> GetFullList()
        {
            using (var context = new SchoolDataBase())
            {
                return context.Employees
                    .Include(rec => rec.User)
                    .Select(CreateViewModel)
                    .ToList();
            }
        }

        public List<EmployeeViewModel> GetFilteredList(EmployeeBindingModel model)
        {
            throw new NotImplementedException();
        }

        public EmployeeViewModel GetElement(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var schoolDataBase = new SchoolDataBase())
            {
                var Employee = schoolDataBase.Employees
                   .Include(rec => rec.User)
                   .FirstOrDefault(rec => rec.User.Login == model.Login ||
                   rec.UserId == model.Id);

                return Employee != null ? CreateViewModel(Employee) : null;
            }
        }

        public void Insert(EmployeeBindingModel model)
        {
            using (var schoolDataBase = new SchoolDataBase())
            {
                schoolDataBase.Employees.Add(CreateModel(model, new Employee(), schoolDataBase));
                schoolDataBase.SaveChanges();
            }
        }

        public void Update(EmployeeBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(EmployeeBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
