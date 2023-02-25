using Microsoft.AspNetCore.Mvc;
using Payroll.Business.Services;
using Payroll.DataAccess.Models;

namespace Payroll.Web.Controllers
{
    public class MissionController : Controller
    {
        private readonly MissionService _missionService;

        public MissionController(MissionService missionService)
        {
            _missionService = missionService;
        }

        [HttpPost, ActionName("Add")]
        public IActionResult Add(Mission mission)
        {
            HttpContext.Session.TryGetEmployee(out Employee? employee);

            if (employee?.Role != "Manager" && employee?.Id != mission.EmployeeId)
            {
                return BadRequest("Недостаточно доступа");
            }

            _missionService.SaveMission(mission);

            return RedirectToAction("Details", "Employee",new{ employeeId = mission.EmployeeId});
        }

        [HttpPost]
        public IActionResult Edit(int id, Mission mission)
        {
            var existingMission = _missionService.GetMissionById(id);
            existingMission.Description = mission.Description;
            existingMission.Date = mission.Date;
            existingMission.WorkingTime = mission.WorkingTime;

            _missionService.UpdateMission(existingMission);
            return Ok();
        }

        [HttpPost]
        public IActionResult Remove(int missionId)
        {
            var mission = _missionService.GetMissionById(missionId);
            _missionService.RemoveMission(mission);

            return RedirectToAction("Details", "Employee", new { employeeId  = mission.EmployeeId});
        }
    }
}
