using CMS.API.Models;
using CMS.DATA.Entities;

namespace CMS.API.Services.ServicesInterface
{
    public interface IQuizesService
    {
        Task<IEnumerable<Quiz>> GetQuizAysnc();
        Task<ResponseDto<Quiz>> GetQuizByIdAsync(string id);
        Task<ResponseDto<Quiz>> GetByLesson(string lessonId);
        Task<ResponseDto<Quiz>> GetByUser(string userId);
    }
}