using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models;

namespace Payroll.Business.Services
{

    public class AuthorizationService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public AuthorizationService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee GetRoleEmployee(string name)
        {
            var employee = _employeeRepository.GetEmployeeByName(name);

            return employee;
        }
        public bool EmployeeExist(string name, string role)
        {
            var employee = _employeeRepository.GetEmployeeByName(name);

            if (employee != null && employee.Role != role)
            {
                return true;
            }

            return false;
        }

        public void AddEmployee(string name, string role)
        {
            _employeeRepository.SaveEmployee(new Employee(name, role));
        }
    }
}
