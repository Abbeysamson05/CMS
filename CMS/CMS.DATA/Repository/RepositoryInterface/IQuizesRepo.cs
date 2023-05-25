using CMS.DATA.Entities;

namespace CMS.DATA.Repository.RepositoryInterface
{
    public interface IQuizesRepo
    {
        Task<IEnumerable<Quiz>> GetAllQuizAsync();
        Task<Quiz> GetQuizByIdAsync(string quizId);
        Task<IEnumerable<Quiz>> GetQuizByLessonAsync(string LessonId);
        Task<IEnumerable<Quiz>> GetQuizByUserAsync(string userId);
    }
}