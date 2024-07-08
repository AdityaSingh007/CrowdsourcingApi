using Microsoft.EntityFrameworkCore;
using SampleMinimalApi.EfCore.Entity;

namespace SampleMinimalApi.EfCore
{
    public class DatabaseContext: DbContext
    {

        public DbSet<Employee> employees { get; set; }

        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 1, Name = "Test", Department = "I&T" });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 2, Name = "Test1", Department = "I&A" });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
