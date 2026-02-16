using Microsoft.AspNetCore.Mvc;

namespace HassanBank.API.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
