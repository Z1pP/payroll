using Payroll.DataAccess.DataBase;
using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models;
using Payroll.DataAccess.Models.Employees;

namespace Payroll.DataAccess.Repositories
{
    public class EmployeeRepository : IBaseRepository<Employee>
    {
        private readonly MyDbContext _dbContext;
        public EmployeeRepository(MyDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public EmployeeRepository()
        {
                
        }

        public IQueryable<Employee> GetAll()
        {
            return _dbContext.Employees;
        }

        public async Task Delete(Employee entity)
        {
            _dbContext.Employees.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Create(Employee entity)
        {
            await _dbContext.Employees.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Employee> Update(Employee entity)
        {
            _dbContext.Employees.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

    }
}