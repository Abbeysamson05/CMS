using CMS.API.Models;
using CMS.DATA.Entities;

namespace CMS.API.Services.ServicesInterface
{
    public interface IStacksService
    {
        ResponseDto<List<string>> GetStacks();
        Task<ResponseDto<Stack>> GetStackbyId(string id);
    }
}