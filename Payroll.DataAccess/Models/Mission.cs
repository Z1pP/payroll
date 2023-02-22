using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll.DataAccess.Models
{
    public class Mission
    {
        public int Id { get; set; }
        public Employee? Employee { get; set; }
        public string? Discription { get; set; }
        public int WorkingTime { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow.Date;
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