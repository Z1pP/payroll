using Microsoft.AspNetCore.Mvc;
using Payroll.Business.Services;

namespace Payroll.Web.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly AuthorizationService _authorization;
        public AuthorizationController(AuthorizationService authorization)
        {
            _authorization = authorization;
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

            var employee = _authorization.GetRoleEmployee(name);

            if (employee == null)
            {
                return BadRequest("Такого сотрудника у нас нет");
            }

            HttpContext.Session.Set(employee); //записываем сотдрудника в сессию
            
            return RedirectToAction("Index","Home");
        }

        [HttpPost, ActionName("Registration")]
        public IActionResult Registration(string name, string role)
        {
            bool result = _authorization.RegistationEmployee(name, role);

            if (result == true)
            {
                return RedirectToAction("Index", "Authorization");
            }

            ModelState.AddModelError("Role", "Сотрудник с такой должностью уже существует");
            return RedirectToAction("Index", "Authorization");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}