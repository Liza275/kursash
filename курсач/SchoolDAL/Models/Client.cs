using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolDAL.Models
{
    public class Client
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        [ForeignKey("ClientId")]
        public virtual List<Society> Societies { get; set; }

        [ForeignKey("ClientId")]
        public virtual List<Payment> Payments { get; set; }
    }
}
