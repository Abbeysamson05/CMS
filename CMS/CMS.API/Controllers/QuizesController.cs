using CMS.API.Services.ServicesInterface;
using CMS.DATA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizesController : ControllerBase
    {
        private readonly IQuizesService _quizesService;

        public QuizesController(IQuizesService quizesService)
        {
            _quizesService = quizesService;
        }

        [HttpGet("All")]
        public async Task<ActionResult> GetAllQuiz()
        {
            try
            {
                return Ok(await _quizesService.GetQuizAysnc());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retreiving data from the database");
            }
        }

        [HttpGet("{quizId}")]
        public async Task<ActionResult<Quiz>> GetQuizById(string quizId)
        {
            try
            {
                return Ok(await _quizesService.GetQuizByIdAsync(quizId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retreiving data from the database");
            }
        }

        [HttpGet("lesson/{lessonId}")]
        public async Task<ActionResult<Quiz>> GetQuizByLessonId(string lessonId)
        {
            try
            {
                return Ok(await _quizesService.GetByLesson(lessonId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retreiving data from the database");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<Quiz>> GetQuizByUserId(string userId)
        {
            try
            {
                return Ok(await _quizesService.GetByUser(userId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retreiving data from the database");
            }
        }


    }
}