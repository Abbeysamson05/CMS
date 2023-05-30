using CMS.API.Services.ServicesInterface;
using CMS.DATA.DTO;
using CMS.DATA.Entities;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.API.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly ICoursesRepo _coursesRepo;

        public CoursesService(ICoursesRepo coursesRepo)
        {
            _coursesRepo = coursesRepo;
        }

       public async Task<ResponseDTO<bool>> DeleteCourseAsync(string courseId)
        {
            try
            {
                var courseResponse = await _coursesRepo.DeleteCourseAsync(courseId);
                return courseResponse;
            }
            catch (Exception ex)
            {

                return new ResponseDTO<bool>()
                {
                    DisplayMessage = "Error",
                    StatusCode = 500,
                    ErrorMessages = new List<string> { "Error deleting course" }
                };
            }
        }
        public async Task<ResponseDTO<Course>> GetCourseById(string courseId)
        {
            try
            {
                var courseResponse = await _coursesRepo.GetCourseById(courseId);
                return courseResponse;
            }
            catch (Exception ex)
            {

                return new ResponseDTO<Course>()
                {
                    DisplayMessage = "Error",
                    StatusCode = 500,
                    ErrorMessages = new List<string> { "Error getting course" }
                };
            }
        }

        public void SetCourseAsCompleted(string courseId)
        {
            try
            {
                _coursesRepo.SetCourseAsCompleted(courseId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<ResponseDTO<Course>> UpdateCourseAsync(string courseId, UpdateCourseDTO course)
        {
            try
            {
                var courseResponse = await _coursesRepo.UpdateCourseAsync(courseId, course);
                return courseResponse;
            }
            catch (Exception ex)
            {
                return new ResponseDTO<Course>()
                {
                    DisplayMessage = "Error",
                    StatusCode = 500,
                    ErrorMessages = new List<string> { "Error updating course" }
                };
            }
        }
         [Authorize(Roles = "Facilitator, Admin")]
        [Authorize(Policy = "can_add")]
        [HttpPost("add")]
        public async Task<ActionResult<ResponseDto<AddCourseDto>>> AddCourse([FromBody] AddCourseDto addCourseDto)
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
        [Authorize]
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
}