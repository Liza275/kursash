using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDAL.Models
{
    public class Cost
    {
        public int Id { get; set; }

        [Required]
        public decimal Sum { get; set; }

        public string Description { get; set; }

        [ForeignKey("CostId")]
        public virtual List<SocietyCost> Societies { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
