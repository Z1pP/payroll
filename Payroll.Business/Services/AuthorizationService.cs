using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models;

namespace Payroll.DataAccess.Services
{

    public class AuthorizationService
    {
        private readonly IEmployeeRepository employeeRepository;
        public AuthorizationService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Employee GetRoleEmployee(string name)
        {
            var employee = employeeRepository.GetEmployeeByName(name);

            if(employee == null)
            {
                return null;
            }

            return employee;
        }
        public bool RegistationEmployee(string name, string role)
        {
            var employee = employeeRepository.GetEmployeeByName(name);

            if (employee == null) 
            {
                employee = new Employee(name, role);

                employeeRepository.SaveEmployee(employee);
            }

            else if (employee.RoleIsConstain(role))
            {
                return false;
            }

            return true;
        }

    }
}
