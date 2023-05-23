using CMS.API.Services.ServicesInterface;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.API.Services
{
    public class PermissionsService : IPermissionsService
    {
        private readonly IPermissionsRepo _permissionsRepo;

        public PermissionsService(IPermissionsRepo permissionsRepo)
        {
            _permissionsRepo = permissionsRepo;
        }
    }
}