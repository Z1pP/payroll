using Microsoft.AspNetCore.Mvc;

namespace Payroll.Web.Controllers
{
    public class AuthorizationController : Controller
    {       
        public IActionResult Index()
        {
            return View();
        }       
    }
}