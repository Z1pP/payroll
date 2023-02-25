
using Payroll.DataAccess.Models;

namespace Payroll.DataAccess.Interfaces
{
    public interface IMissionRepository
    {
        public List<Mission> GetMissions();

        public void SaveMission(Mission mission);
    }
}
