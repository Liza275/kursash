using SchoolBusinessLogic.Enum;
using System;
using System.ComponentModel;

namespace SchoolBusinessLogic.BindingModel
{
    public class ClientBindingModel
    {
        public int? Id { get; set; }

        [DisplayName("Имя")]
        public string ClientName { get; set; }

        [DisplayName("Фамилия")]
        public string ClientSurname { get; set; }

        [DisplayName("Отчество")]
        public string ClientPatronymic { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime DateBirth { get; set; }

        [DisplayName("Логин")]
        public string Login { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }

        public Role Role { get; set; }
    }
}
