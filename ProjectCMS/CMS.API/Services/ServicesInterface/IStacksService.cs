using CMS.API.Models;

namespace CMS.API.Services.ServicesInterface
{
    public interface IStacksService
    {
        ResponseDto<List<string>> GetStacks();
    }
}