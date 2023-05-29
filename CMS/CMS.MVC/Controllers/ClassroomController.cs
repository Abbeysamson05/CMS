using Microsoft.AspNetCore.Mvc;

namespace CMS.MVC.Controllers
{
    public class ClassroomController : Controller
    {
        public bool toggleState { get; set; } = false;

        public IActionResult LearningContent()
        {
            return View();
        }

        public IActionResult QuizPage()
        {
            ViewBag.ShowSuccessModal = toggleState;

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
    }
}
