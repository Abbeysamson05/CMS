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
                    AddedById = addCoourseDto.UserId,
                    IsCompleted = addCoourseDto.IsCompleted,
                    DateCreated = DateTime.Now,
                    IsDeleted = false



                };

                var CourseResult = await _coursesRepo.AddCourse(NewCourse);
                if (CourseResult != null)
                {
                    response.StatusCode = 200;
                    response.DisplayMessage = "You have successfully added a course";
                    response.Result = CourseResult;
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
                    response.StatusCode = 200;
                    response.DisplayMessage = "Successful";
                    response.Result = result;
                    return response;
                }
                response.StatusCode = 404;
                response.DisplayMessage = "Not Successful";
                return response;
            }
            catch (Exception)
            {
                response.ErrorMessages = new List<string> { "Error trying to get list of all courses" };
                response.StatusCode = 400;
                return response;
            }




        }
    }
}