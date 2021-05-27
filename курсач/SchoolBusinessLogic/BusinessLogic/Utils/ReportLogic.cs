using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.HelperModel;
using SchoolBusinessLogic.Interface;
using SchoolBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly ISocietyStorage _societyStorage;

        private readonly ILessonStorage _lessonStorage;

        private readonly IPaymentStorage _paymentStorage;

        private readonly ICostStorage _costStorage;

        public ReportLogic(ISocietyStorage societyStorage, ILessonStorage lessonStorage, IPaymentStorage paymentStorage, ICostStorage costStorage)
        {
            _societyStorage = societyStorage;
            _lessonStorage = lessonStorage;
            _paymentStorage = paymentStorage;
            _costStorage = costStorage;
        }

        private List<LessonViewModel> GetLessonsByDate(ReportBindingModel model)
        {
            var lessonsByDate = _lessonStorage.GetFilteredList(new LessonBindingModel
            {
                DateTo = model.DateTo,
                DateFrom = model.DateFrom,
                EmployeeId = model.EmployeeId
            });

            foreach(var lesson in lessonsByDate)
            {
                lesson.Payments = _paymentStorage.GetFilteredList(new PaymentBindingModel {
                    DateTo = model.DateTo,
                    DateFrom = model.DateFrom,
                    LessonId = lesson.Id });
            }

            return lessonsByDate;
        }

        public void SaveSocietiesToWordFile(ReportBindingModel model)
        {
            SaveToWordLogic.CreateDoc(new ListInfo
            {
                FileName = model.FileName,
                Title = "Список кружков",
                Lessons = _lessonStorage.GetFilteredList(new LessonBindingModel
                {
                    SelectedLessons = model.SelectedLessons,
                    EmployeeId = model.EmployeeId
                })
            });
        }

        public void SaveSocietiesToExcelFile(ReportBindingModel model)
        {
            SaveToExcelLogic.CreateDoc(new ListInfo
            {
                FileName = model.FileName,
                Title = "Список кружков",
                Lessons = _lessonStorage.GetFilteredList(new LessonBindingModel
                {
                    SelectedLessons = model.SelectedLessons,
                    EmployeeId = model.EmployeeId
                })
            });
        }

        public void SaveSocietiesToPdfFile(ReportBindingModel model)
        {
            SaveToPdfLogic.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список кружков",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Lessons = GetLessonsByDate(model)
            });
        }
    }
}
