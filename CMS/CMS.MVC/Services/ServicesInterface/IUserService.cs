using CMS.API.Models;

namespace CMS.MVC.Services.ServicesInterface
{
    public interface IUserService
    {
        Task<UploadResponseDto<bool>> DeleteFileAsync(string publicId, string email);
        Task<UploadResponseDto<Dictionary<string, string>>> UploadFileAsync(IFormFile file, string email);
    }
}
