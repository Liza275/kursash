using System;
using System.ComponentModel;

namespace SchoolBusinessLogic.ViewModel
{
    public class PaymentViewModel
    {
        public int Id { get; set; }

        public int LessonId { get; set; }

        [DisplayName("Занятие")]
        public string LessonName { get; set; }

        [DisplayName("Сумма")]
        public decimal Sum { get; set; }

        [DisplayName("Всего к оплате")]
        public decimal FullSum { get; set; }

        public int ClientId { get; set; }

        [DisplayName("ФИО клиента")]
        public string ClientName { get; set; }

        [DisplayName("Дата оплаты")]
        public DateTime PaymentDate { get; set; }
    }
}
