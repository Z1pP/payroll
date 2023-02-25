
using Payroll.DataAccess.Models;

namespace Payroll.DataAccess.Interfaces
{
    public interface IMissionRepository
    {
        public List<Mission> GetMissions();

        public void SaveMission(Mission mission);
        public void RemoveMission(Mission mission);
        public  Mission GetMissionById(int id);
        public void UpdateMission(Mission mission);
    }
}
