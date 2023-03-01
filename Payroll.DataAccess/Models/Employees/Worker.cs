namespace Payroll.DataAccess.Models.Employees
{
    public class Worker : Employee
    {
        private const decimal BaseSalary = 120_000m;
        public Worker(string name, string role):base(name,role)
        {
            
        }

        public override decimal GetSalary(int totalHours)
        {
            this.TotalHoursWorked = totalHours;

            return (decimal)TotalHoursWorked / TotalWorkingHoursPerMonth * BaseSalary;
        }
    }
}
