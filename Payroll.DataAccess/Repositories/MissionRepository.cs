using Payroll.DataAccess.DataBase;
using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models;

namespace Payroll.DataAccess.Repositories
{
    public class MissionRepository : IMissionRepository
    {
        private MyDbContext dbContext;

        public MissionRepository()
        {
            
        }
        public MissionRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void RemoveMission(Mission mission)
        {
            dbContext.Missions.RemoveRange(mission);
            dbContext.SaveChanges();
        }

        public List<Mission> GetMissions()
        {
            return dbContext.Missions.ToList();
        }

        public void SaveMission(Mission mission)
        {
            dbContext.Missions.Add(mission);

            dbContext.SaveChanges();
        }

        public Mission GetMissionById(int id)
        {
            var mission = dbContext.Missions.SingleOrDefault(x => x.Id == id);

            return mission;
        }

        public void UpdateMission(Mission mission)
        {
            dbContext.Missions.Update(mission);
            dbContext.SaveChanges();
        }
    }
}
