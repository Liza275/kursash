using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.ViewModel;
using System.Collections.Generic;

namespace SchoolBusinessLogic.Interface
{
    public interface ICostStorage
    {
        List<CostViewModel> GetFullList();

        List<CostViewModel> GetFilteredList(CostBindingModel model);

        CostViewModel GetElement(CostBindingModel model);

        void Insert(CostBindingModel model);

        void Update(CostBindingModel model);

        void Delete(CostBindingModel model);
    }
}
