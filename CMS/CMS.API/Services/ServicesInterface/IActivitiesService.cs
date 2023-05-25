using CMS.DATA.Entities;

namespace CMS.API.Services.ServicesInterface
{
    public interface IActivitiesService
    {
        List<Activity>GetAllActivities();
        Activity DeleteActivity(string id);
    }
}