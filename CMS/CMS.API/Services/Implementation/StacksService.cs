using CMS.API.Services.ServicesInterface;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.API.Services
{
    public class StacksService : IStacksService
    {
        private readonly IStacksRepo _stacksRepo;

        public StacksService(IStacksRepo stacksRepo)
        {
            _stacksRepo = stacksRepo;
        }
    }
}