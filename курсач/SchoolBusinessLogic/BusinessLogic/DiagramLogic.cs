using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.ViewModel;
using System;
using System.Linq;

namespace SchoolBusinessLogic.BusinessLogic
{
    public class DiagramLogic
    {
        private readonly LessonLogic lessonLogic;

        public DiagramLogic(LessonLogic lessonLogic)
        {
            this.lessonLogic = lessonLogic;
        }

        public DiagramViewModel GetDiagramByLessonsPrice(DiagramBindingModel model)
        {
            return new DiagramViewModel
            {
                Title = "Диаграмма стоимости всех занятий",
                ColumnName = "Занятие",
                ValueName = "Стоимость",
                Data = lessonLogic.Read(new LessonBindingModel
                {
                    EmployeeId = model.EmployeeId.Value
                }).Select(rec => new Tuple<string, decimal>(rec.LessonName, rec.Price)).ToList()
            };
        }

        public DiagramViewModel GetDiagramByLessonsCount(DiagramBindingModel model)
        {
            return new DiagramViewModel
            {
                Title = "Диаграмма количества занятий",
                ColumnName = "Занятие",
                ValueName = "Количество",
                Data = lessonLogic.Read(new LessonBindingModel
                {
                    EmployeeId = model.EmployeeId.Value
                }).Select(rec => new Tuple<string, decimal>(rec.LessonName, rec.LessonCount)).ToList()
            };
        }

        public DiagramViewModel GetDiagramByPayments(DiagramBindingModel model)
        {
            return new DiagramViewModel
            {
                Title = "Диаграмма оплат занятий",
                ColumnName = "Дата оплаты",
                ValueName = "Сумма",
                Data = lessonLogic.Read(new LessonBindingModel
                {
                    Id = model.LessonId
                }).FirstOrDefault().Payments.Select(rec => new Tuple<string, decimal>(rec.PaymentDate.ToShortDateString(), rec.Sum))
                    .GroupBy(rec => rec.Item1)
                    .Select(rec => new Tuple<string, decimal>(rec.Key, rec.Sum(rec => rec.Item2))).ToList()
            };
        }
    }
}
