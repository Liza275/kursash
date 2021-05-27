using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SchoolBusinessLogic.BindingModel
{
    public class SocietyBindingModel
    {
        public int? Id { get; set; }

        [DisplayName("Название")]
        public string SocietyName { get; set; }

        [DisplayName("Дата записи на кружок")]
        public DateTime DateCreate { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        [DisplayName("Возрастное ограничение")]
        public int AgeLimit { get; set; }

        [DisplayName("Сумма")]
        public decimal Sum { get; set; }

        public List<int> Lessons { get; set; }

        public int ClientId { get; set; }

        public List<int> SelectedSocieties { get; set; }
    }
}
