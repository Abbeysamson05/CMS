using CMS.DATA.Entities;

namespace CMS.DATA.Repository.RepositoryInterface
{
    public interface IStacksRepo
    {
       Task<IEnumerable<Stack>> GetStacks();
       Task<bool?> UpdateStackbyId(string stackId, Stack entity);
    }
}