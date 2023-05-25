using CMS.API.Models;
using CMS.API.Services.ServicesInterface;
using CMS.DATA.DTO;
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

        [HttpPost("add")]
        public async Task<ActionResult<ResponseDto<AddQuizDto>>> AddQuiz([FromBody] AddQuizDto addQuizDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addQuiz = await _quizesService.AddQuiz(addQuizDto);
            if (addQuiz.StatusCode == 200)
            {
                return Ok(addQuiz);
            }
            else if (addQuiz.StatusCode == 400)
            {
                return NotFound(addQuiz);
            }
            else
            {
                return BadRequest(addQuiz);
            }
        }


        [HttpPatch("{quizId}/update")]
        public async Task<ActionResult<ResponseDto<AddQuizDto>>> UpdateQuiz(string quizId, [FromBody] UpdateDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updateQuiz = await _quizesService.UpdateQuiz(quizId, updateDto);
            if (updateQuiz.StatusCode == 200)
            {
                return Ok(updateQuiz);
            }
            else if (updateQuiz.StatusCode == 400)
            {
                return NotFound(updateQuiz);

            }
            else
            {
                return BadRequest(updateQuiz);
            }
        }

        [HttpDelete("{quizId}/delete")]
        public async Task<ActionResult<ResponseDto<bool>>> DeleteQuiz(string quizId)
        {

            var DeleteQuiz = await _quizesService.DeleteQuiz(quizId);

            if (DeleteQuiz.StatusCode == 200)
            {
                return Ok(DeleteQuiz);
            }
            else if (DeleteQuiz.StatusCode == 400)
            {
                return NotFound(DeleteQuiz);

            }
            else
            {
                return BadRequest(DeleteQuiz);
            }

        }
    }
}
