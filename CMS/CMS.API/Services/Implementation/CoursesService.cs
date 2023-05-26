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
                    ErrorMessages = new List<string> { "Error deleting course" }
                };
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
    }
}