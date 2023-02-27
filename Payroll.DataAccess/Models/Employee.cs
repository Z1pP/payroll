using System.ComponentModel.DataAnnotations;

namespace Payroll.DataAccess.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }
        public int TotalWorkingHoursPerMonth { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow.Date;
        public List<Mission> Missions { get; set; } = new List<Mission>();
        public Employee()
        {

        }
 
        public Employee(string name, string role)
        {
            Name = name;
            Role = role;
        }
    }
}
