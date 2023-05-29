using Microsoft.AspNetCore.Mvc;

namespace CMS.MVC.Controllers
{
    public class ClassroomController : Controller
    {
        public IActionResult LearningContent()
        {
            return View();
        }

        public IActionResult Quiz()
        {
            return View();
        }
        public IActionResult FacilitatorScreen()
        {
            return View();
        }
        public IActionResult ResourcePage()
        {
            return View();
        }
        public IActionResult QuizScore()
        {
            return View();
        }
        public IActionResult DecadevScreen()
        {
            return View();
        }
    }
}
