using CMS.MVC.Services.ServicesInterface;
using Microsoft.AspNetCore.Mvc;

namespace CMS.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
