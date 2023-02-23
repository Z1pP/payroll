using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll.DataAccess.Models
{
    public class Mission
    {
        public int Id { get; set; }       
        public string? Discription { get; set; }
        public int WorkingTime { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow.Date;

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Mission()
        {

        }
        public Mission(string disctiption, int workingTime)
        {
            Discription = disctiption;
            WorkingTime = workingTime;
        }
    }
}