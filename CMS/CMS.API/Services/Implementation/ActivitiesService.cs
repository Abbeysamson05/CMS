using CMS.API.Services.ServicesInterface;
using CMS.DATA.Entities;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.API.Services
{
    public class ActivitiesService : IActivitiesService
    {
        private readonly IActivitiesRepo _activitiesRepo;

        public ActivitiesService(IActivitiesRepo activitiesRepo)
        {
            _activitiesRepo = activitiesRepo;
        }

        public List<Activity>GetAllActivities()
        {
            return _activitiesRepo.GetAll();
        }

        public Activity DeleteActivity(string id)
        {

        return _activitiesRepo.Delete(id);

        }
    }

}