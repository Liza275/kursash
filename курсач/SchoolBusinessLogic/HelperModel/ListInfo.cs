using SchoolBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.HelperModel
{
    public class ListInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<LessonViewModel> Lessons { get; set; }
    }
}
