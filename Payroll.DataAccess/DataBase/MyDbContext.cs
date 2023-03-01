using Microsoft.EntityFrameworkCore;
using Payroll.DataAccess.Models;
using Payroll.DataAccess.Models.Employees;

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
            modelBuilder.Entity<Manager>();
            modelBuilder.Entity<Worker>();
            modelBuilder.Entity<Freelancer>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
