using CMS.DATA.Entities;

namespace CMS.DATA.Repository.RepositoryInterface
{
    public interface ICoursesRepo
    {
        Task<Course> AddCourse(Course entity);
        Task<IEnumerable<Course>> GetAllCourse();
    }
}