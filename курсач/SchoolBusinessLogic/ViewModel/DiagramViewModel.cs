using System;
using System.Collections.Generic;

namespace SchoolBusinessLogic.ViewModel
{
    public class DiagramViewModel
    {
        public string ColumnName { get; set; }

        public string ValueName { get; set; }

        public string Title { get; set; }

        public List<Tuple<string, decimal>> Data { get; set; }
    }
}
