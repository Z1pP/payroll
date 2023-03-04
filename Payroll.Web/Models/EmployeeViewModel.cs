using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models.Employees;
using Payroll.DataAccess.Repositories;

namespace Payroll.Web.Models
{
    public class EmployeeViewModel
    {

        private IBaseRepository<Employee> _employeeRepository;
        public  Employee Employee { get; set; }
        public  List<Employee> Employees { get; set; }

        public EmployeeViewModel(int id)
        {
            _employeeRepository = new EmployeeRepository();

            Employee = _employeeRepository.GetAll()
                .SingleOrDefault(x => x.Id == id);
            Employees = _employeeRepository.GetAll()
                .ToList();
        }

    }
}
