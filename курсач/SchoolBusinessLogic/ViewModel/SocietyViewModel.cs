using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SchoolBusinessLogic.ViewModel
{
    public class SocietyViewModel
    {
        public int Id { get; set; }

        [DisplayName("Кружок")]
        public string SocietyName { get; set; }

        [DisplayName("Возрастное ограничение")]
        public int AgeLimit { get; set; }

        [DisplayName("Дата записи на кружок")]
        public DateTime DateCreate { get; set; }

        [DisplayName("Стоимость")]
        public decimal Sum { get; set; }

        [DisplayName("Занятия")]
        public List<LessonViewModel> Lessons { get; set; }

        public int ClientId { get; set; }

        [DisplayName("ФИО клиента")]
        public string ClientName { get; set; }

        public List<CostViewModel> Costs { get; set; }
    }
}
