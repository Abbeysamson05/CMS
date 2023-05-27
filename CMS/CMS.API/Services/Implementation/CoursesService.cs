using CMS.API.Models;
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




        public async Task<ResponseDto<Course>> AddCourse(AddCourseDto addCoourseDto)
        {
            var response = new ResponseDto<Course>();
            try
            {
                var NewCourse = new Course
                {
                    Name = addCoourseDto.Name,
                    AddedBy = addCoourseDto.AddedBy
                };
                var QuizResult = await _coursesRepo.AddCourse(NewCourse);
                if (QuizResult != null)
                {
                    response.StatusCode = 200;
                    response.DisplayMessage = "You have successfully added a course";
                    response.Result = QuizResult;
                    return response;
                }
                response.ErrorMessages = new List<string> { "Error trying to add a course" };
                response.StatusCode = 404;
                response.Result = null;
                return response;
            }
            catch (Exception)
            {
                response.ErrorMessages = new List<string> { "Error trying to add a course" };
                response.StatusCode = 400;
                return response;
            }
        }

        public async Task<ResponseDto<IEnumerable<Course>>> GetAllCousrse()
        {
            var response = new ResponseDto<IEnumerable<Course>>();
            try
            {
                var result = await _coursesRepo.GetAllCourse();
                if (result != null && result.Any())
                {
                    response.StatusCode = StatusCodes.Status200OK;
                    response.DisplayMessage = "Successful";
                    response.Result = result;
                    return response;
                }
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.DisplayMessage = "Not Successful";
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.DisplayMessage = "Error";
                response.ErrorMessages = new List<string> { ex.Message };
                return response;
            }




        }
    }
}