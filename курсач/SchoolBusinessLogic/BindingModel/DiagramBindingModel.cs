using SchoolBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.BindingModel
{
    public class DiagramBindingModel
    {
        public int? EmployeeId { get; set; }

        public int? LessonId { get; set; }

        public DiagramViewModel[] DiagramsData { get; set; }
    }
}
