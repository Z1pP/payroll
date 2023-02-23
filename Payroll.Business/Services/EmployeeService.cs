using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models;

namespace Payroll.Business.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) 
        {
            _employeeRepository = employeeRepository;
        }

        public List<Employee> GetEmployees()
        {
           return _employeeRepository.GetEmployees();
        }

        public Employee GetEmployeeById(int id) 
        {
            var employee = _employeeRepository.GetEmployeeById(id);

            return employee;
        }

    }
}
