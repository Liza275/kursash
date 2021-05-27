using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDAL.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        [ForeignKey("EmployeeId")]
        public List<Lesson> Lessons { get; set; }

        [ForeignKey("EmployeeId")]
        public List<Cost> Costs { get; set; }
    }
}
