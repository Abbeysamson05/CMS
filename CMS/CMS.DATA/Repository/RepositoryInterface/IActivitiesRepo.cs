using CMS.DATA.Entities;

namespace CMS.DATA.Repository.RepositoryInterface
{
    public interface IActivitiesRepo
    {
        List<Activity> GetAll();
        Activity Delete(string id);
    }
}