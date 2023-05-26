using CMS.DATA.Enum;

namespace CMS.MVC.Services.ServicesInterface
{
    public interface IUserService
    {
        Task<bool> RequestPermission(string userId);
        Task<bool> GrantPermission(string userId, Permissions claims);

    }
}
