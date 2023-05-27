using CMS.API.Services.ServicesInterface;
using CMS.DATA.Repository.RepositoryInterface;
using Serilog;

namespace CMS.API.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly ICoursesRepo _coursesRepo;

        public CoursesService(ICoursesRepo coursesRepo)
        {
            _coursesRepo = coursesRepo;
        }

        public void SetCourseAsCompleted(string courseId)
        {
            try
            {

                _coursesRepo.SetCourseAsCompleted(courseId);
            }
            catch (Exception ex)
            {

                Log.Error(ex, $"Error occurred while marking course {courseId} as completed");


                throw;
            }
        }
    }
}