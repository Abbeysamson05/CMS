using CMS.DATA.Context;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.DATA.Repository.Implementation
{
    public class LessonsRepo : ILessonsRepo
    {
        private readonly CMSDbContext _context;

        public LessonsRepo(CMSDbContext context)
        {
            _context = context;
        }
    }
}