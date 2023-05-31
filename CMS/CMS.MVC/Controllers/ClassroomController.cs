using CMS.MVC.Models;
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
            var result = new CKEditor();
            return View(result);
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
