using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.Interface;
using SchoolBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;

namespace SchoolBusinessLogic.BusinessLogic
{
    public class LessonLogic
    {
        private readonly ILessonStorage _lessonStorage;

        public LessonLogic(ILessonStorage lessonStorage)
        {
            _lessonStorage = lessonStorage;
        }

        public List<LessonViewModel> Read(LessonBindingModel model)
        {
            if (model == null)
            {
                return _lessonStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<LessonViewModel> { _lessonStorage.GetElement(model) };
            }
            return _lessonStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(LessonBindingModel model)
        {
            var lesson = _lessonStorage.GetElement(new LessonBindingModel
            {
                LessonName = model.LessonName
            });
            if (lesson != null && lesson.Id != model.Id)
            {
                throw new Exception("Уже есть занятие с таким названием");
            }
            if (model.Id.HasValue)
            {
                _lessonStorage.Update(model);
            }
            else
            {
                _lessonStorage.Insert(model);
            }
        }

        public void Delete(LessonBindingModel model)
        {
            var lesson = _lessonStorage.GetElement(new LessonBindingModel
            {
                Id = model.Id
            });
            if (lesson == null)
            {
                throw new Exception("Занятие не найдено");
            }
            _lessonStorage.Delete(model);
        }
    }
}
