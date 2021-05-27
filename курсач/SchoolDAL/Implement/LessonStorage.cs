using Microsoft.EntityFrameworkCore;
using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.Interface;
using SchoolBusinessLogic.ViewModel;
using SchoolDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolDAL.Implement
{
    public class LessonStorage : ILessonStorage
    {
        private Lesson CreateModel(LessonBindingModel model, Lesson lesson)
        {
            lesson.LessonName = model.LessonName;
            lesson.LessonCount = model.LessonCount;
            lesson.Price = model.Price;
            lesson.EmployeeId = model.EmployeeId;

            return lesson;
        }

        public static LessonViewModel CreateViewModel(Lesson lesson)
        {
            return new LessonViewModel
            {
                Id = lesson.Id,
                LessonName = lesson.LessonName,
                LessonCount = lesson.LessonCount,
                Price = lesson.Price,
                EmployeeId = lesson.EmployeeId,
                EmployeeName = lesson.Employee.User.Name,
                Societies = lesson.SocietyLessons.Select(rec => SocietyStorage.CreateViewModel(rec.Society)).ToList(),
                Payments = lesson.Payments.Select(rec => PaymentStorage.CreateViewModel(rec)).ToList(),
            };
        }

        public List<LessonViewModel> GetFullList()
        {
            using (var context = new SchoolDataBase())
            {
                return context.Lessons
                    .Include(rec => rec.Employee)
                    .ThenInclude(rec => rec.User)
                    .Include(rec => rec.SocietyLessons)
                    .ThenInclude(rec => rec.Society)
                    .Include(rec => rec.Payments)
                    .Select(CreateViewModel)
                    .ToList();
            }
        }

        public List<LessonViewModel> GetFilteredList(LessonBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new SchoolDataBase())
            {
                return context.Lessons
                    .Include(rec => rec.Employee)
                    .ThenInclude(rec => rec.User)
                    .Include(rec => rec.SocietyLessons)
                    .ThenInclude(rec => rec.Society)
                    .Include(rec => rec.Payments)
                    .Where(rec => rec.EmployeeId == model.EmployeeId && model.SelectedLessons == null && !model.DateFrom.HasValue && !model.DateTo.HasValue ||
                    model.SelectedLessons != null && model.SelectedLessons.Contains(rec.Id) && rec.EmployeeId == model.EmployeeId ||
                    model.DateFrom.HasValue && model.DateTo.HasValue && rec.EmployeeId == model.EmployeeId &&
                    rec.Payments.Any(rec => rec.PaymentDate.Date >= model.DateFrom.Value.Date && rec.PaymentDate.Date <= model.DateTo.Value.Date))
                    .Select(CreateViewModel)
                    .ToList();
            }
        }

        public LessonViewModel GetElement(LessonBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new SchoolDataBase())
            {
                var lesson = context.Lessons
                    .Include(rec => rec.Employee)
                    .ThenInclude(rec => rec.User)
                    .Include(rec => rec.SocietyLessons)
                    .ThenInclude(rec => rec.Society)
                    .Include(rec => rec.Payments)
                    .FirstOrDefault(rec => rec.LessonName == model.LessonName ||
                    rec.Id == model.Id);

                return lesson != null ? CreateViewModel(lesson) : null;
            }
        }

        public void Insert(LessonBindingModel model)
        {
            using (var context = new SchoolDataBase())
            {
                context.Lessons.Add(CreateModel(model, new Lesson()));
                context.SaveChanges();
            }
        }

        public void Update(LessonBindingModel model)
        {
            using (var context = new SchoolDataBase())
            {
                var lesson = context.Lessons.FirstOrDefault(rec => rec.Id == model.Id);

                if (lesson == null)
                {
                    throw new Exception("Занятие не найдено");
                }

                CreateModel(model, lesson);
                context.SaveChanges();
            }
        }

        public void Delete(LessonBindingModel model)
        {
            using (var context = new SchoolDataBase())
            {
                var lesson = context.Lessons.FirstOrDefault(rec => rec.Id == model.Id);

                if (lesson == null)
                {
                    throw new Exception("Занятие не найдено");
                }

                context.Lessons.Remove(lesson);
                context.SaveChanges();
            }
        }
    }
}
