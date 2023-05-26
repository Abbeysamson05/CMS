using CMS.API.Models;
using CMS.DATA.DTO;
using CMS.DATA.Entities;

namespace CMS.API.Services.ServicesInterface
{
    public interface IStacksService
    {
        ResponseDto<List<string>> GetStacks();
        Task<ResponseDto<List<UserDto>>> GetUsersByStack(string stackId);
        Task<ResponseDto<IEnumerable<Stack>>> GetStacks();
    }
}