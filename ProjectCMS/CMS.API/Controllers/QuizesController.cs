using CMS.API.Services.ServicesInterface;
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
    }
}