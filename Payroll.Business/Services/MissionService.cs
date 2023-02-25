
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

    }
}
