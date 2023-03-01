using System.ComponentModel.DataAnnotations;
using Payroll.DataAccess.Models.Employees;

namespace Payroll.DataAccess.Models
{
    public class Mission
    {
        public int Id { get; set; }
        [Required]
        public string? Description { get; set; }
        public int WorkingTime { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow.Date;

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Mission()
        {

        }
        public Mission(string desctiption, int workingTime)
        {
            Description = desctiption;
            WorkingTime = workingTime;
        }
    }
}