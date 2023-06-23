using CMS.DATA.DTO;
using CMS.DATA.Entities;
using CMS.DATA.Enum;
using CMS.MVC.Models;
using CMS.MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMS.MVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }
        [HttpGet]
        [Route("dashboard/studentdashboard/{userid}/{gencourseid}")]
        public async Task<IActionResult> StudentDashboard(string userid, string gencourseid)
        {
            var model = new StudentDashBoardViewModel();

            var User = await _userManager.FindByIdAsync(userid);
            model.User = User;
            var getUserClaim = await _userManager.GetClaimsAsync(User);
            var courseId = string.Empty;
            if (gencourseid == "null")
            {
                if (getUserClaim != null)
                {
                    foreach (var claim in getUserClaim)
                    {
                        if (claim.Type == Permissions.can_access_dotnet_curriculum.ToString())
                        {
                            courseId = "ebec65c8-bd4b-45c5-9b57-8ecd6b171c53";
                            ViewBag.StudentStack = "Backend(.Net)";
                        }
                        else if (claim.Type == Permissions.can_access_java_curriculum.ToString())
                        {
                            ViewBag.StudentStack = "Java";
                            courseId = "8fd8c418-43b1-4e3c-95ec-6c5db0fb93c6";
                        }
                        else
                        {
                            ViewBag.StudentStack = "Node";
                            courseId = "56402c31-1997-4a76-8888-af2545d9a9be";
                        }
                    }
                }
            }
            else
            {
                courseId = gencourseid;
            }

            foreach (var claim in getUserClaim)
            {
                if (claim.Type == Permissions.can_access_dotnet_curriculum.ToString())
                {
                    ViewBag.StudentStack = "Backend(.Net)";
                }
                else if (claim.Type == Permissions.can_access_java_curriculum.ToString())
                {
                    ViewBag.StudentStack = "Java";   
                }
                else
                {
                    ViewBag.StudentStack = "Node";
                }
            }
            using (var client = new HttpClient())
            {
                var apiUrl = _configuration["baseUrl:localhost"] + ConstantSubBaseEnpoint.GetCoursebyId + courseId;
                var response = await client.GetFromJsonAsync<ResponseDto<Course>>(apiUrl);
                model.course = response.Result;
            }
            return View(model);
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

        [HttpGet]
        public IActionResult DecadevsPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FacilitatorsPage()
        {
            return View();
        }


    }

}
