using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models;

namespace Payroll.Business.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMissionRepository _missionRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IMissionRepository missionRepository)
        {
            _employeeRepository = employeeRepository;
            _missionRepository = missionRepository;
        }

        public List<Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }

        public void RemoveEmployee(int id)
        {
            _employeeRepository.RemoveEmployeeById(id);
        }
    }
}
