using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models;
using Payroll.DataAccess.Models.Employees;

namespace Payroll.Business.Services
{
    public class EmployeeService
    {
        private readonly IBaseRepository<Employee> _employeeRepository;
        private readonly IBaseRepository<Mission> _missionRepository;

        public EmployeeService(IBaseRepository<Employee> employeeRepository, IBaseRepository<Mission> missionRepository)
        {
            _employeeRepository = employeeRepository;
            _missionRepository = missionRepository;
        }

        public List<Employee> GetEmployees()
        {
            return _employeeRepository.GetAll().ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return GetEmployees().SingleOrDefault(x => x.Id == id);
        }

        public async Task RemoveEmployee(Employee employee)
        {
            await _employeeRepository.Delete(employee);
        }

        //Получаем список заданий которые выполнил сотрудник
        public List<Mission> GetEmployeeMissions(int id)
        {
            return _missionRepository.GetAll()
                .Where(x => x.EmployeeId == id)
                .ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.Update(employee);
        }

    }
}
