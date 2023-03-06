using Payroll.DataAccess.DataBase;
using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models;

namespace Payroll.DataAccess.Repositories
{
    public class MissionRepository : IBaseRepository<Mission>
    {
        private MyDbContext _dbContext;

        public MissionRepository()
        {
            
        }
        public MissionRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Mission> GetAll()
        {
            return _dbContext.Missions;
        }

        public async Task Delete(Mission entity)
        {
            _dbContext.Missions.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Create(Mission entity)
        {
            await _dbContext.Missions.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Mission> Update(Mission entity)
        {
            _dbContext.Missions.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
