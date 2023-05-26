using CMS.API.Models;
using CMS.DATA.Entities;

namespace CMS.API.Services.ServicesInterface
{
    public interface IStacksService
    {
        Task<ResponseDto<Stack>> GetStackbyId(string id);
        Task<ResponseDto<IEnumerable<Stack>>> GetStacks();
    }
}