using CMS.API.Models;
using CMS.DATA.DTO;
using CMS.DATA.Entities;

namespace CMS.API.Services.ServicesInterface
{
    public interface IStacksService
    {
        Task<ResponseDto<IEnumerable<Stack>>> GetStacks();
        Task<ResponseDto<string>> UpdateStackById(string stackid, UpdateStacksDto stack);
    }
}