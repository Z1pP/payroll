using System.ComponentModel.DataAnnotations;

namespace Payroll.DataAccess.Models.Employees
{
    public abstract class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }
        public int TotalHoursWorked { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow.Date;
        public List<Mission> Missions { get; set; } = new List<Mission>();

        public const int TotalWorkingHoursPerMonth = 160;
        public Employee()
        {

        }

        public Employee(string name, string role)
        {
            Name = name;
            Role = role;
        }

        public abstract decimal GetSalary(int totalHours);
    }
}
