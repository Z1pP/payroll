
using Payroll.DataAccess.DataBase;
using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models;

namespace Payroll.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyDbContext _dbContext;
        public EmployeeRepository(MyDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public EmployeeRepository()
        {
                
        }

        public void RemoveEmplyee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Пустой объект");
            }

            var missions = _dbContext.Missions.Where(s => s.EmployeeId == employee.Id);

            _dbContext.Missions.RemoveRange(missions);
            _dbContext.Employees.RemoveRange(employee);
            _dbContext.SaveChanges();
        }

        public void RemoveEmployeeById(int id)
        {
            var employee = GetEmployeeById(id);

            RemoveEmplyee(employee);

        }

        public void SaveEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), "Пустой объект");

            _dbContext.Employees.Add(employee);

            _dbContext.SaveChanges();
        }
        public void UpdateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Пустой объект");
            }
            _dbContext.Update(employee);

            _dbContext.SaveChanges();
        }
        public Employee GetEmployeeById(int id)
        {
            var employee = _dbContext.Employees.SingleOrDefault(x => x.Id == id);

            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Пустой объект");
            }

            return employee;
        }

        public Employee GetEmployeeByName(string name)
        {
            var employee = _dbContext.Employees.SingleOrDefault(x => x.Name.ToUpper() == name.ToUpper());

            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return _dbContext.Employees.ToList();
        }
    }
}