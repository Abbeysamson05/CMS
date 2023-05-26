using CMS.DATA.Entities;

namespace CMS.DATA.Repository.RepositoryInterface
{
    public interface IStacksRepo
    {
        List<string> GetStacks();
        Task<Stack> GetStackAsync(string stackid);
    }
}