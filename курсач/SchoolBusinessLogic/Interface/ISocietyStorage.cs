using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.Interface
{
    public interface ISocietyStorage
    {
        List<SocietyViewModel> GetFullList();

        List<SocietyViewModel> GetFilteredList(SocietyBindingModel model);

        SocietyViewModel GetElement(SocietyBindingModel model);

        void Insert(SocietyBindingModel model);

        void Update(SocietyBindingModel model);

        void Delete(SocietyBindingModel model);
    }
}
