using CMS.DATA.Entities;

namespace CMS.DATA.Repository.RepositoryInterface
{
    public interface IStacksRepo
    {
        Task<Stack> GetStackAsync(string stackid);
      Task<IEnumerable<Stack>> GetStacks();

    }
}