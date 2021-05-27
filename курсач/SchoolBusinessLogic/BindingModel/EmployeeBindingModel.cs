using System;
using System.ComponentModel;

namespace SchoolBusinessLogic.BindingModel
{
    public class EmployeeBindingModel
    {
        public int? Id { get; set; }

        [DisplayName("Имя")]
        public string EmployeeName { get; set; }

        [DisplayName("Фамилия")]
        public string EmployeeSurname { get; set; }

        [DisplayName("Отчество")]
        public string EmployeePatronymic { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime DateBirth { get; set; }

        [DisplayName("Логин")]
        public string Login { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
