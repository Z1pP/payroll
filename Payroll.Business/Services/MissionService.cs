using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models;

namespace Payroll.Business.Services
{
    public class MissionService
    {
        private readonly IBaseRepository<Mission> _missionRepository;

        public MissionService(IBaseRepository<Mission> missionRepository)
        {
            _missionRepository = missionRepository;
        }

        public void SaveMission(Mission mission)
        {
            _missionRepository.Create(mission);
        }

        public void RemoveMission(Mission mission)
        {
            _missionRepository.Delete(mission);
        }

        public Mission GetMissionById(int id)
        {
            return _missionRepository.GetAll()
                .SingleOrDefault(x => x.Id == id);
        }

        public void UpdateMission(Mission mission)
        {

            _missionRepository.Update(mission);
        }

        
    }
}
