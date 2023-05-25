using CMS.DATA.Entities;

namespace CMS.DATA.Repository.RepositoryInterface
{
    public interface IQuizesRepo
    {
        Task<Quiz> AddQuiz(Quiz entity);
        Task<Quiz> DeleteQuizAsync(Quiz entity);
        Task<Quiz> UpdateQuiz(Quiz entity);
        Task<Quiz> GetQuizByIdAsync(string Id);
    }
}