using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDAL.Models
{
    public class Society
    {
        public int Id { get; set; }

        [Required]
        public string SocietyName { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        [Required]
        public int AgeLimit { get; set; }

        [Required]
        public decimal Sum { get; set; }

        public int ClientId { get; set; }

        [ForeignKey("SocietyId")]
        public virtual List<SocietyLesson> SocietyLessons { get; set; }

        [ForeignKey("SocietyId")]
        public virtual List<SocietyCost> SocietyCosts { get; set; }

        public virtual Client Client { get; set; }
    }
}
