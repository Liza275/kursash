using System.ComponentModel;

namespace SchoolBusinessLogic.BindingModel
{
    public class BindCostToSocietyBindingModel
    {
        [DisplayName("Статья затрат")]
        public int CostId { get; set; }

        [DisplayName("Кружок")]
        public int SocietyId { get; set; }

        [DisplayName("Дополнительные расходы")]
        public decimal AdditionalCost { get; set; }
    }
}
