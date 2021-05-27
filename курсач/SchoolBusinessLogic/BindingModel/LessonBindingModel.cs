using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SchoolBusinessLogic.BindingModel
{
    public class LessonBindingModel
    {
        public int? Id { get; set; }

        [DisplayName("Название")]
        public string LessonName { get; set; }

        [DisplayName("Количество занятий")]
        public int LessonCount { get; set; }

        [DisplayName("Стоимость")]
        public decimal Price { get; set; }

        public int EmployeeId { get; set; }

        public List<int> SelectedLessons { get; set; }

        public DateTime? DateTo { get; set; }

        public DateTime? DateFrom { get; set; }
    }
}
