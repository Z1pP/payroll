
using System.ComponentModel.DataAnnotations;

namespace Payroll.DataAccess.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int TotalWorkingHoursPerMonth { get; set; }
        public List<Mission> Missions { get; set; } = new List<Mission>();
        public Employee()
        {

        }
 
        public Employee(string name, string role)
        {
            Name = name;
            Role = role;
        }

        public bool RoleIsConstain(string role)
        {
            if (Role == role)
                return true;

            return false;
        }
    }
}
