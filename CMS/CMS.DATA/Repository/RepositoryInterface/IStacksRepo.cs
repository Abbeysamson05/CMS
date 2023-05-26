
using CMS.DATA.DTO;
using CMS.DATA.Entities;


namespace CMS.DATA.Repository.RepositoryInterface
{
    public interface IStacksRepo
    {
        Task<List<UserDto>> GetUsersByStack(string stackId);
        Task<bool> DeleteStack(string stackId);
       Task<IEnumerable<Stack>> GetStacks();
    }
}