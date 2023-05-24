using CMS.DATA.Entities;

namespace CMS.DATA.Repository.RepositoryInterface
{
    public interface IQuizesRepo
    {
        Task<IEnumerable<Quiz>> GetAllQuizAsync();
        Task<Quiz> GetQuizByIdAsync(string quizId);
        Task<Quiz> GetQuizByLessonAsync(string LessonId);
        Task<Quiz> GetQuizByUserAsync(string userId);
    }
}