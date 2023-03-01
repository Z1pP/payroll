namespace Payroll.DataAccess.Models.Employees
{
    public class Freelancer : Employee
    {
        // Почасовая ставка
        private const decimal HourlyWage = 1000m;

        public Freelancer(string name, string role) :base(name,role)
        {
            
        }
        public override decimal GetSalary(int totalHours)
        {
            this.TotalHoursWorked = totalHours;

            return (decimal)TotalHoursWorked * HourlyWage;
        }
    }
}
