using CMS.DATA.DTO;
 using CMS.DATA.Enum;
﻿using CMS.DATA.DTO;
using CMS.DATA.Enum;
using CMS.MVC.Services.Implementation;

 namespace CMS.MVC.Services.ServicesInterface
{
    public interface IUserService
    {
        Task<ResponseDTO<bool>> DeleteFileAsync(string publicId, string email);
        Task<ResponseDTO<Dictionary<string, string>>> UploadFileAsync(IFormFile file, string email);
        Task<bool> RequestPermission(string userId);
        Task<bool> GrantPermission(string userId, Permissions claims);
       public Task<ResponseDto<bool>> DeleteUser(string userId);
     public Task<ResponseDto<bool>> SetActiveStatus(string userId, bool status);


    }
}

