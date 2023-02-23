using Payroll.DataAccess.DataBase;
using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models;

namespace Payroll.DataAccess.Repositories
{
    public class MissionRepository : IMissionRepository
    {
        private MyDbContext dbContext;

        public MissionRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Mission> GetMissions()
        {
            return dbContext.Missions.ToList();
        }
    }
}
