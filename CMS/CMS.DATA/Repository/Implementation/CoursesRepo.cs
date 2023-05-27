using CMS.DATA.Context;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.DATA.Repository.Implementation
{
    public class CoursesRepo : ICoursesRepo
    {
        private readonly CMSDbContext _context;

        public CoursesRepo(CMSDbContext context)
        {
            _context = context;
        }

        public void SetCourseAsCompleted(string courseId)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == courseId);

            if (course != null)
            {
                course.IsCompleted = true;
                _context.SaveChanges();
            }


        }


    }
}