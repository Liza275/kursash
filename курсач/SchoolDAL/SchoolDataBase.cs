using Microsoft.EntityFrameworkCore;
using SchoolDAL.Models;
namespace SchoolDAL
{
    public class SchoolDataBase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=schooldatabase;Username=postgres;Password=3228");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<User> Users { set; get; }

        public virtual DbSet<Client> Clients { set; get; }

        public virtual DbSet<Society> Societies { set; get; }

        public virtual DbSet<Payment> Payments { set; get; }

        public virtual DbSet<Employee> Employees { set; get; }

        public virtual DbSet<Lesson> Lessons { set; get; }

        public virtual DbSet<Cost> Costs { set; get; }

        public virtual DbSet<SocietyLesson> SocietyLessons { set; get; }  
        
        public virtual DbSet<SocietyCost> SocietyCosts { set; get; }        
    }
}
