using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models.Employees;

namespace Payroll.Business.Services
{

    public class AuthorizationService
    {
        private readonly IBaseRepository<Employee> _employeeRepository;
        public AuthorizationService(IBaseRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //Получаем должность сотрудника
        public Employee GetRoleEmployee(string name)
        {
            var employee = _employeeRepository.GetAll()
                .SingleOrDefault(x => x.Name == name);

            return employee;
        }

        //Проверяем существует ли такой сотрудник в Бд
        public bool EmployeeExist(string name, string role)
        {
            var employee = _employeeRepository.GetAll()
                .SingleOrDefault(x => x.Name == name && x.Role == role);

            //Если такой сотрудник есть и его роль не повторяется
            if (employee == null)
                return false;

            return true;
        }

        //Создаем нового сотрудника
        public async Task AddEmployee(string name, string role)
        {
            Employee employee = role switch
            {
                "Manager" => new Manager(name, role),
                "Worker" => new Worker(name, role),
                "Freelancer" => new Freelancer(name, role),
                _ => throw new ArgumentException("Данная должность отсутсвует", name)
            };

            await _employeeRepository.Create(employee);
        }
    }

}
