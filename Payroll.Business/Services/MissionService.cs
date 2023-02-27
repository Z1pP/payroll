using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models;

namespace Payroll.Business.Services
{
    public class MissionService
    {
        private readonly IMissionRepository _missionRepository;

        public MissionService(IMissionRepository missionRepository)
        {
            _missionRepository = missionRepository;
        }

        public void SaveMission(Mission mission)
        {
            _missionRepository.SaveMission(mission);
        }

        public void RemoveMission(Mission mission)
        {
            _missionRepository.RemoveMission(mission);
        }

        public Mission GetMissionById(int id)
        {
            return _missionRepository.GetMissionById(id);
        }

        public void UpdateMission(Mission mission)
        {

            _missionRepository.UpdateMission(mission);
        }

        
    }
}
