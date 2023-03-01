using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models.Employees;
using Payroll.DataAccess.Repositories;

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

            //Если такой сотрудник есть и его роль не повторяется
            if (employee == null || employee.Role != role)
            {
                return false;
            }

            return true;
        }

        //Создаем нового сотрудника
        public void AddEmployee(string name, string role)
        {
            Employee employee = role switch
            {
                "Manager" => new Manager(name, role),
                "Worker" => new Worker(name, role),
                "Freelancer" => new Freelancer(name, role),
                _ => throw new ArgumentException("Данная должность отсутсвует", name)
            };

            _employeeRepository.SaveEmployee(employee);
        }
    }

}
