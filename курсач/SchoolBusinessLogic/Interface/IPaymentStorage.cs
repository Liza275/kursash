using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.ViewModel;
using System.Collections.Generic;

namespace SchoolBusinessLogic.Interface
{
    public interface IPaymentStorage
    {
        List<PaymentViewModel> GetFullList();

        List<PaymentViewModel> GetFilteredList(PaymentBindingModel model);

        PaymentViewModel GetElement(PaymentBindingModel model);

        void Insert(PaymentBindingModel model);

        void Update(PaymentBindingModel model);

        void Delete(PaymentBindingModel model);
    }
}
