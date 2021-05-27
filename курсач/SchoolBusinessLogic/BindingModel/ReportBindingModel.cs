using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolBusinessLogic.BindingModel
{
    public class ReportBindingModel
    {
        [ValidateNever]
        public string FileName { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        [DisplayName("Занятия")]
        public List<int> SelectedLessons { get; set; }

        [ValidateNever]
        public int EmployeeId { get; set; }
    }
}
