using CMS.API.Services.ServicesInterface;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.API.Services
{
    public class QuizesService : IQuizesService
    {
        private readonly IQuizesRepo _quizesRepo;

        public QuizesService(IQuizesRepo quizesRepo)
        {
            _quizesRepo = quizesRepo;
        }
    }
}