
using Payroll.DataAccess.Models.Employees;

namespace Payroll.DataAccess.Interfaces
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetAll();
        Task Delete(T entity);
        Task Create(T entity);

        Task<T> Update(T entity);
    }
}
