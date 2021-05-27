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
    public class SocietyStorage : ISocietyStorage
    {
        public static SocietyViewModel CreateViewModel(Society society)
        {
            return new SocietyViewModel
            {
                Id = society.Id,
                SocietyName = society.SocietyName,
                AgeLimit = society.AgeLimit,
                DateCreate = society.DateCreate,
                Sum = society.Sum,
                ClientId = society.ClientId,
                ClientName = society.Client?.User.Name
            };
        }

        private Society CreateModel(SocietyBindingModel model, Society society, SchoolDataBase context)
        {
            society.SocietyName = model.SocietyName;
            society.AgeLimit = model.AgeLimit;
            society.Sum = model.Sum;
            society.ClientId = model.ClientId;
            if (society.Id == 0)
            {
                society.DateCreate = DateTime.Now;
                context.Societies.Add(society);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var lessons = context.SocietyLessons
                    .Where(rec => rec.SocietyId == model.Id.Value)
                    .ToList();

                context.SocietyLessons.RemoveRange(lessons
                    .Where(rec => !model.Lessons.Contains(rec.LessonId))
                    .ToList());
                context.SaveChanges();

                foreach (var updateLesson in lessons)
                {
                    model.Lessons.Remove(updateLesson.LessonId);
                }
            }

            foreach (var lesson in model.Lessons)
            {
                context.SocietyLessons.Add(new SocietyLesson
                {
                    SocietyId = society.Id,
                    LessonId = lesson
                });
                context.SaveChanges();
            }

            return society;
        }

        public void Delete(SocietyBindingModel model)
        {
            using (var context = new SchoolDataBase())
            {
                var society = context.Societies.FirstOrDefault(rec => rec.Id == model.Id);

                if (society == null)
                {
                    throw new Exception("Кружок не найден");
                }

                context.Societies.Remove(society);
                context.SaveChanges();
            }
        }

        public SocietyViewModel GetElement(SocietyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new SchoolDataBase())
            {
                var society = context.Societies
                    .Include(rec => rec.SocietyLessons)
                    .ThenInclude(rec => rec.Lesson)
                    .ThenInclude(rec => rec.Employee)
                    .ThenInclude(rec => rec.User)
                    .Include(rec => rec.Client)
                    .ThenInclude(rec => rec.User)
                    .Include(rec => rec.SocietyCosts)
                    .ThenInclude(rec => rec.Cost)
                    .FirstOrDefault(rec => rec.SocietyName == model.SocietyName ||
                    rec.Id == model.Id);

                return society != null ? CreateViewModel(society) : null;
            }
        }

        public List<SocietyViewModel> GetFilteredList(SocietyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new SchoolDataBase())
            {
                return context.Societies
                    .Include(rec => rec.SocietyLessons)
                    .ThenInclude(rec => rec.Lesson)
                    .ThenInclude(rec => rec.Employee)
                    .ThenInclude(rec => rec.User)
                    .Include(rec => rec.Client)
                    .ThenInclude(rec => rec.User)
                    .Include(rec => rec.SocietyCosts)
                    .ThenInclude(rec => rec.Cost)
                    .Where(rec => model.DateFrom.HasValue && model.DateTo.HasValue && rec.ClientId == model.ClientId &&
                    rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date ||
                    !model.DateFrom.HasValue && !model.DateTo.HasValue && rec.ClientId == model.ClientId && model.SelectedSocieties.Contains(rec.Id))
                    .Select(CreateViewModel)
                    .ToList();
            }
        }

        public List<SocietyViewModel> GetFullList()
        {
            using (var context = new SchoolDataBase())
            {
                return context.Societies
                    .Include(rec => rec.SocietyLessons)
                    .ThenInclude(rec => rec.Lesson)
                    .ThenInclude(rec => rec.Employee)
                    .ThenInclude(rec => rec.User)
                    .Include(rec => rec.Client)
                    .ThenInclude(rec => rec.User)
                    .Include(rec => rec.SocietyCosts)
                    .ThenInclude(rec => rec.Cost)
                    .Select(CreateViewModel)
                    .ToList();
            }
        }

        public void Insert(SocietyBindingModel model)
        {
            using (var context = new SchoolDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Society(), context);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(SocietyBindingModel model)
        {
            using (var context = new SchoolDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var society = context.Societies.FirstOrDefault(rec => rec.Id == model.Id);

                        if (society == null)
                        {
                            throw new Exception("Кружок не найден");
                        }

                        CreateModel(model, society, context);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
