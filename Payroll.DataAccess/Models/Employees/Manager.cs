
namespace Payroll.DataAccess.Models.Employees
{
    public class Manager:Employee
    {
        private const decimal BaseSalary = 200_000m;
        private const decimal Bonus = 20_000m;

        public Manager(string name, string role):base(name,role)
        {
            
        }
        public override decimal GetSalary(int totalHours)
        {
            this.TotalHoursWorked = totalHours;

            decimal totalSalary = (decimal)TotalHoursWorked / TotalWorkingHoursPerMonth * BaseSalary;

            if (TotalHoursWorked > TotalWorkingHoursPerMonth)
                totalSalary += Bonus;

            return totalSalary;
        }
    }
}
