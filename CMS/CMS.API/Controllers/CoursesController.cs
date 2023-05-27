using CMS.API.Models;
using CMS.API.Services.ServicesInterface;
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


        [HttpPatch]
        [Route("{courseId}")]
        // [Authorize]
        public IActionResult MarkCourseAsCompleted(string courseId, bool completed = true)
        {
            try
            {
                if (completed)
                {
                    _coursesService.SetCourseAsCompleted(courseId);
                    var response = new ResponseDto<string>
                    {
                        StatusCode = 200,
                        DisplayMessage = "Course marked as completed",
                        Result = "Success"
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ResponseDto<string>
                    {
                        StatusCode = 400,
                        DisplayMessage = "Invalid value for 'completed' parameter",
                        Result = "Failure"
                    };

                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                var response = new ResponseDto<string>
                {
                    StatusCode = 500,
                    DisplayMessage = $"Error occurred while marking course as completed: {ex.Message}",
                    Result = "Failure"
                };

                return StatusCode(500, response);
            }
        }


    }
}