using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDAL.Models
{
    public class Lesson
    {
        public int Id { get; set; }

        [Required]
        public string LessonName { get; set; }

        [Required]
        public int LessonCount { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("LessonId")]
        public virtual List<SocietyLesson> SocietyLessons { get; set; }

        [ForeignKey("LessonId")]
        public virtual List<Payment> Payments { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
