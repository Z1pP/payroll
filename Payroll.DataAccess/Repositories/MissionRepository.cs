using Payroll.DataAccess.DataBase;
using Payroll.DataAccess.Interfaces;

namespace Payroll.DataAccess.Repositories
{
    public class MissionRepository : IMissionRepository
    {
        private MyDbContext dbContext;

        public MissionRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
