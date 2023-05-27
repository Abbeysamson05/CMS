using CMS.API.Models;
using CMS.API.Services.ServicesInterface;
using CMS.DATA.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService _coursesService;

        public CoursesController(ICoursesService coursesService)
        {
            _coursesService = coursesService;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ResponseDto<AddQuizDto>>> AddQuiz([FromBody] AddCourseDto addCourseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addCourse = await _coursesService.AddCourse(addCourseDto);
            if (addCourse.StatusCode == 200)
            {
                return Ok(addCourse);
            }
            else if (addCourse.StatusCode == 400)
            {
                return NotFound(addCourse);
            }
            else
            {
                return BadRequest(addCourse);
            }
        }

        [HttpGet("All")]
        public async Task<ActionResult> GetAllCourses()
        {
            var result = await _coursesService.GetAllCousrse();
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else if (result.StatusCode == 404)
            {
                return NotFound(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}