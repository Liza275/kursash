using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.ViewModel;
using System.Collections.Generic;

namespace SchoolBusinessLogic.Interface
{
    public interface ILessonStorage
    {
        List<LessonViewModel> GetFullList();

        List<LessonViewModel> GetFilteredList(LessonBindingModel model);

        LessonViewModel GetElement(LessonBindingModel model);

        void Insert(LessonBindingModel model);

        void Update(LessonBindingModel model);

        void Delete(LessonBindingModel model);
    }
}
