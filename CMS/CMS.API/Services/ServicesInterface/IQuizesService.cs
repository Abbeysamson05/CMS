using CMS.API.Models;
using CMS.DATA.DTO;
using CMS.DATA.Entities;

namespace CMS.API.Services.ServicesInterface
{
    public interface IQuizesService
    {
        Task<ResponseDto<Quiz>> AddQuiz(AddQuizDto addQuizDto);
        Task<ResponseDto<Quiz>> UpdateQuiz(string Id, UpdateDto updateDto);
        Task<ResponseDto<bool>> DeleteQuiz(string Id);
    }
}