using CMS.DATA.DTO;
using CMS.DATA.Entities;

namespace CMS.API.Services.ServicesInterface
{
    public interface IStacksService
    {
        Task<ResponseDto<List<UserDto>>> GetUsersByStack(string stackId);
        Task<ResponseDto<string>> DeleteStack(string stackId);
       Task<ResponseDto<IEnumerable<Stack>>> GetStacks();
    }
}