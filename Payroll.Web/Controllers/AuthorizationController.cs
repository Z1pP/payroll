using Microsoft.AspNetCore.Mvc;
using Payroll.DataAccess.Services;

namespace Payroll.Web.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly AuthorizationService authorization;
        public AuthorizationController(AuthorizationService authorization)
        {
            this.authorization = authorization;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost, ActionName("Login")]
        public IActionResult Login(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return View();
            }

            var employee = authorization.GetRoleEmployee(name);

            if (employee == null)
            {
                return View();
            }

            return RedirectToAction("Index","Home", employee);
        }

        [HttpPost, ActionName("Registration")]
        public IActionResult Registration(string name, string role)
        {
            bool result = authorization.RegistationEmployee(name, role);

            if (result == true)
            {
                return RedirectToAction("Index", "Authorization");
            }

            ModelState.AddModelError("Role", "Сотрудник с такой должностью уже существует");
            return RedirectToAction("Index", "Authorization");
        }
    }
}