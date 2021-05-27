using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.ViewModel;
using System.Collections.Generic;

namespace SchoolBusinessLogic.Interface
{
    public interface IClientStorage
    {
        List<ClientViewModel> GetFullList();

        List<ClientViewModel> GetFilteredList(ClientBindingModel model);

        ClientViewModel GetElement(ClientBindingModel model);

        void Insert(ClientBindingModel model);

        void Update(ClientBindingModel model);

        void Delete(ClientBindingModel model);
    }
}
