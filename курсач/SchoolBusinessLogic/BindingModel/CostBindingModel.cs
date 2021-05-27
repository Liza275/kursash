using System.ComponentModel;

namespace SchoolBusinessLogic.BindingModel
{
    public class CostBindingModel
    {
        public int? Id { get; set; }

        [DisplayName("Сумма")]
        public decimal Sum { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Кружок")]
        public int? SocietyId { get; set; }

        public int EmployeeId { get; set; }

        public decimal? AdditionalCost { get; set; }
    }
}
