using System;
using System.ComponentModel;

namespace SchoolBusinessLogic.BindingModel
{
    public class PaymentBindingModel
    {
        public int? Id { get; set; }

        public int LessonId { get; set; }

        [DisplayName("Сумма")]
        public decimal Sum { get; set; }

        public int ClientId { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
