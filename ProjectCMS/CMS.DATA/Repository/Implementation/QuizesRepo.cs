using CMS.DATA.Context;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.DATA.Repository.Implementation
{
    public class QuizesRepo : IQuizesRepo
    {
        private readonly CMSDbContext _context;

        public QuizesRepo(CMSDbContext context)
        {
            _context = context;
        }
    }
}