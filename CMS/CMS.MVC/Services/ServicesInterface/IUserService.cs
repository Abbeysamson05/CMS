using CMS.DATA.DTO;

namespace CMS.MVC.Services.ServicesInterface
{
    public interface IUserService
    {
       public Task<ResponseDto<bool>> DeleteUser(string userId);
     public Task<ResponseDto<bool>> SetActiveStatus(string userId, bool status);
