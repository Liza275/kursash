using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SchoolBusinessLogic.ViewModel
{
    public class CostViewModel
    {
        [DisplayName("Номер затраты")]
        public int Id { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Сумма")]
        public decimal Sum { get; set; }

        [DisplayName("Кружки")]
        public List<Tuple<string, decimal>> Societies { get; set; }

        public int EmployeeId { get; set; }

        [DisplayName("ФИО работника")]
        public string EmployeeName { get; set; }
    }
}
