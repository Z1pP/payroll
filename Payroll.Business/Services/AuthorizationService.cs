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

        //Получаем должность сотрудника
        public Employee GetRoleEmployee(string name)
        {
            var employee = _employeeRepository.GetEmployeeByName(name);

            return employee;
        }

        //Проверяем существует ли такой сотрудник в Бд
        public bool EmployeeExist(string name, string role)
        {
            var employee = _employeeRepository.GetEmployeeByName(name);

            if (employee != null && employee.Role != role)
            {
                return true;
            }

            return false;
        }

        //Создаем нового сотрудника
        public void AddEmployee(string name, string role)
        {
            _employeeRepository.SaveEmployee(new Employee(name, role));
        }
    }
}
