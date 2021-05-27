using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.Interface;
using SchoolBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;

namespace SchoolBusinessLogic.BusinessLogic
{
    public class PaymentLogic
    {
        private readonly IPaymentStorage _paymentStorage;

        public PaymentLogic(IPaymentStorage PaymentStorage)
        {
            _paymentStorage = PaymentStorage;
        }

        public List<PaymentViewModel> Read(PaymentBindingModel model)
        {
            if (model == null)
            {
                return _paymentStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PaymentViewModel> { _paymentStorage.GetElement(model) };
            }
            return _paymentStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(PaymentBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _paymentStorage.Update(model);
            }
            else
            {
                _paymentStorage.Insert(model);
            }
        }

        public void Delete(PaymentBindingModel model)
        {
            var element = _paymentStorage.GetElement(new PaymentBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Оплата не найдена");
            }
            _paymentStorage.Delete(model);
        }
    }
}


