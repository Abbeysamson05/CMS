using CMS.API.Services.ServicesInterface;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.API.Services
{
    public class LessonsService : ILessonsService
    {
        private readonly ILessonsRepo _lessonsRepo;

        public LessonsService(ILessonsRepo lessonsRepo)
        {
            _lessonsRepo = lessonsRepo;
        }
    }
}