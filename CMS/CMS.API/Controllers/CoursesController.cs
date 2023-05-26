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
        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetCourseById(string courseId)
        {
            var result = await _coursesService.GetCourseById(courseId);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }else if(result.StatusCode == 404)
            {
                return NotFound(result);
            }
            else
            {
                return BadRequest(result);
            }
            
        }
        [HttpDelete("{courseId}/delete")]
        public async Task<IActionResult> DeleteCourse(string courseId)
        {
            var result = await _coursesService.DeleteCourseAsync(courseId);
            if(result.StatusCode == 200)
            {
                return Ok(result);
            }else if(result.StatusCode == 404)
            {
                return NotFound(result);
            }
            else
            {
                return BadRequest(result);
            }

        }
        [HttpPut("{courseId}/update")]
        public async Task<IActionResult> UpdateCourse(UpdateCourseDTO course, string courseId)
        {
            var result = await _coursesService.UpdateCourseAsync(courseId, course);
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