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
                ModelState.AddModelError("empty","Не корректно введены данные");
            }

            //Получаем сотрудника из бд
            var employee = _authorization.GetRoleEmployee(name);

            if (employee == null)
            {
                ModelState.AddModelError("loginError","Такого сотрудника нет");
                return View("Index", ModelState);
            }

            //Записываем сотдрудника в сессию
            HttpContext.Session.Set(employee); 
            
            return RedirectToAction("Index","Home");
        }

        [HttpPost, ActionName("Registration")]
        public IActionResult Registration(string name, string role)
        {
            try
            {
                //Проверка существует ли такой сотрудник
                bool result = _authorization.EmployeeExist(name, role);

                if (result == true)
                {
                    ModelState.AddModelError("role","Сотрудник уже существует");
                }
                else
                {
                    //Добавляем сотрудника
                    _authorization.AddEmployee(name,role);
                    return View("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("regError","Ошибка при добавлении сотрудника");
            }

            return View("Index",ModelState);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}