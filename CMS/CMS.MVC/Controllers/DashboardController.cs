using Microsoft.AspNetCore.Mvc;

namespace CMS.MVC.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult StudentDashboard()
        {
            return View();
        }

        public IActionResult FacilitatorDashboard()
        {
            return View();
        }

        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult DevsProfile()
        {
            return View();
        }

        public IActionResult DecadevsPage()
        {
            return View();
        }

        public IActionResult FacilitatorsPage()
        {
            return View();
        }


    }

}
