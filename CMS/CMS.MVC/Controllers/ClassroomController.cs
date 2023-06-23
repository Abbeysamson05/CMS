using CMS.DATA.Context;
using CMS.DATA.DTO;
using CMS.DATA.Entities;
using CMS.MVC.Models;
using CMS.MVC.Services.ServicesInterface;
using CMS.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.MVC.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IConfiguration _configuration;
        private readonly CMSDbContext _context;

        public ClassroomController(ICloudinaryService cloudinaryService, IConfiguration configuration, CMSDbContext context)
        {
            _cloudinaryService = cloudinaryService;
            _configuration = configuration;
            _context = context;
        }
        public bool toggleState { get; set; } = false;

        [HttpGet]
        [Route("classroom/learningcontent/{courseid}/{lessonid}")]
        public async Task<IActionResult> LearningContent(string courseid, string lessonid)
        {
            ViewBag.ShowSuccessModal = toggleState;
            var model = new LearningContentViewModel();
            using (var client = new HttpClient())
            {
                var apiUrl = _configuration["baseUrl:localhost"] + ConstantSubBaseEnpoint.GetLessonbyId + lessonid;
                var response = await client.GetFromJsonAsync<ResponseDto<Lesson>>(apiUrl);
                model.Lesson = response.Result;
            }
            using (var client = new HttpClient())
            {
                var apiUrl = _configuration["baseUrl:localhost"] + ConstantSubBaseEnpoint.GetCoursebyId + courseid;
                var response = await client.GetFromJsonAsync<ResponseDto<Course>>(apiUrl);
                model.Course = response.Result;
            }
            if (lessonid != null)
            {
                using (var client = new HttpClient())
                {
                    var apiUrl = _configuration["baseUrl:localhost"] + ConstantSubBaseEnpoint.GetQuizbyLessonId + lessonid;
                    var response = await client.GetFromJsonAsync<ResponseDto<IEnumerable<Quiz>>>(apiUrl);
                    model.Quizs = response.Result;
                }
            }
            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> QuizPage()
        {
            var result = new QuizPageViewModel();
            ViewBag.ShowSuccessModal = toggleState;
            using (var client = new HttpClient())
            {
                var apiUrl = _configuration["baseUrl:localhost"] + ConstantSubBaseEnpoint.GetLessonUri;
                var response = await client.GetFromJsonAsync<ResponseDto<IEnumerable<Lesson>>>(apiUrl);
                result.Lesson = response.Result;
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> QuizPage(QuizPageViewModel model)
        {

            ViewBag.ShowSuccessModal = toggleState;

            using (var client = new HttpClient())
            {
                model.Quiz.AddedById = "36e318aa-6d02-46d9-8048-3e2a8182a6c3";
                model.Quiz.AnswerType = "Objective";
                model.Quiz.DateUpdated = DateTime.UtcNow;
                var apiUrl = _configuration["baseUrl:localhost"] + ConstantSubBaseEnpoint.AddQuiz;
                var response = await client.PostAsJsonAsync<Quiz>(apiUrl, model.Quiz);
                var result = await response.Content.ReadFromJsonAsync<ResponseDto<Quiz>>();
                var addAllOption = new List<string>();
                addAllOption.Add(model.OptionA);
                addAllOption.Add(model.OptionB);
                addAllOption.Add(model.OptionC);
                addAllOption.Add(model.OptionD);
                if (response.IsSuccessStatusCode)
                {
                    foreach (var option in addAllOption)
                    {
                        var quizOption = new QuizOption();
                        quizOption.Option = option;
                        quizOption.DateUpdated = DateTime.UtcNow;
                        quizOption.DateCreated = DateTime.UtcNow;
                        quizOption.IsDeleted = false;
                        quizOption.QuizId = result.Result.Id;
                        await _context.QuizOptions.AddAsync(quizOption);
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction("QuizPage", "Classroom");
                }
            }
            return View();
        }
        public async Task<IActionResult> ResourcePage()
        {
            var result = new ResourcesModel();
            using (var client = new HttpClient())
            {
                var apiUrl = _configuration["baseUrl:localhost"] + ConstantSubBaseEnpoint.GetLessonUri;
                var response = await client.GetFromJsonAsync<ResponseDto<IEnumerable<Lesson>>>(apiUrl);
                var uploadResults = new List<UploadRecord>();
                foreach (var userResult in response.Result)
                {
                    var uploadResult = new UploadRecord();
                    uploadResult.DocName = userResult.Topic;
                    uploadResult.CreatedDate = userResult.DateCreated;
                    uploadResult.Id = userResult.Id;
                    uploadResults.Add(uploadResult);
                }


                result.uploadRecords = uploadResults;
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> ResourcePage(ResourcesModel model)
        {
            try
            {
                var getCourseid = await _context.Courses.FirstOrDefaultAsync(c => c.Name == model.CourseId);
                model.CourseId = getCourseid.Id;
                var uploadVideo = await _cloudinaryService.UploadVideo(model.VideoFile, model.Module.ToString());
                if (uploadVideo.Url.ToString() != null)
                {
                    model.VideoUrl = uploadVideo.Url.ToString();
                    model.PublicId = uploadVideo.PublicId;
                }
                //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                //This will be replace with context of signIn User "36e318aa-6d02-46d9-8048-3e2a8182a6c3"
                model.AddedById = "36e318aa-6d02-46d9-8048-3e2a8182a6c3";
                using (var client = new HttpClient())
                {
                    var apiUrl = _configuration["baseUrl:localhost"] + ConstantSubBaseEnpoint.AddLessonUri;
                    var response = await client.PostAsJsonAsync(apiUrl, model);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("FacilitatorDashboard", "Dashboard");
                    }
                    else
                    {
                        return RedirectToAction("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                return View(model);

            }



        }
        public IActionResult QuizScore()
        {
            return View();
        }
    }
}
