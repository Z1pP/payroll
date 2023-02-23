using Payroll.DataAccess.Models;

namespace Payroll.Web.Models
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
