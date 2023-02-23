using Microsoft.EntityFrameworkCore;
using Payroll.DataAccess.Models;

namespace Payroll.DataAccess.DataBase
{
    public class MyDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                        .HasMany(e => e.Missions)
                        .WithOne(m => m.Employee)
                        .HasForeignKey(m => m.EmployeeId);
        }
    }
}
