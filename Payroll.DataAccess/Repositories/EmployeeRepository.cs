using Payroll.DataAccess.DataBase;
using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models;

namespace Payroll.Business
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyDbContext dbContext;
        public EmployeeRepository(MyDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task DeleteEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Пустой объект");
            }

            dbContext.Remove(employee);
            await dbContext.SaveChangesAsync();
        }
        public async Task SaveEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Пустой объект");
            }

            dbContext.AddAsync(employee);

            await dbContext.SaveChangesAsync();
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = dbContext.Employees.Single(x => x.Id == id);

            return employee;
        }

        public Employee GetEmployeeByName(string name)
        {
            var employee = dbContext.Employees.SingleOrDefault(x => x.Name.ToUpper() == name.ToUpper());

            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return dbContext.Employees.ToList();
        }
    }
}