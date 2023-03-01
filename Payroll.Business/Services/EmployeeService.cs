using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models;
using Payroll.DataAccess.Models.Employees;

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

        public void RemoveEmployee(Employee employee)
        {
            _employeeRepository.RemoveEmplyee(employee);
        }

        //Получаем список заданий которые выполнил сотрудник
        public List<Mission> GetEmployeeMissions(int employeeId)
        {
            var employee = _employeeRepository.GetEmployeeById(employeeId);
            if (employee == null)
            {
                throw new ArgumentException("Сотрудник не найден");
            }

            return _missionRepository.GetMissions().Where(mission => mission.EmployeeId == employeeId).ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.UpdateEmployee(employee);
        }

    }
}
