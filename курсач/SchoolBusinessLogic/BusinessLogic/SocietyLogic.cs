using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.Interface;
using SchoolBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;

namespace SchoolBusinessLogic.BusinessLogic
{
    public class SocietyLogic
    {
        private readonly ISocietyStorage _societyStorage;

        public SocietyLogic(ISocietyStorage SocietyStorage)
        {
            _societyStorage = SocietyStorage;
        }

        public List<SocietyViewModel> Read(SocietyBindingModel model)
        {
            if (model == null)
            {
                return _societyStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SocietyViewModel> { _societyStorage.GetElement(model) };
            }
            return _societyStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(SocietyBindingModel model)
        {
            var society = _societyStorage.GetElement(new SocietyBindingModel
            {
                SocietyName = model.SocietyName
            });
            if (society != null && society.Id != model.Id)
            {
                throw new Exception("Уже есть кружок с таким названием");
            }
            if (model.Id.HasValue)
            {
                _societyStorage.Update(model);
            }
            else
            {
                _societyStorage.Insert(model);
            }
        }

        public void Delete(SocietyBindingModel model)
        {
            var society = _societyStorage.GetElement(new SocietyBindingModel
            {
                Id = model.Id
            });
            if (society == null)
            {
                throw new Exception("Кружок не найден");
            }
            _societyStorage.Delete(model);
        }
    }
}