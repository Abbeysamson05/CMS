using CMS.DATA.Context;
using CMS.DATA.Entities;
using CMS.DATA.Repository.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace CMS.DATA.Repository.Implementation
{
    public class CoursesRepo : ICoursesRepo
    {
        private readonly CMSDbContext _context;

        public CoursesRepo(CMSDbContext context)
        {
            _context = context;
        }




        public async Task<Course> AddCourse(Course entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Courses.AddAsync(entity);
            var Status = await _context.SaveChangesAsync();

            if (Status > 0)
                return entity;

            return null;
        }
        public async Task<IEnumerable<Course>> GetAllCourse()
        {
            return await _context.Courses.ToListAsync();
        }

    }
}