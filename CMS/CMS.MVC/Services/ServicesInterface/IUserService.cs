using CMS.DATA.DTO;

namespace CMS.MVC.Services.ServicesInterface
{
    public interface IUserService
    {
        Task<ResponseDTO<bool>> DeleteFileAsync(string publicId, string email);
        Task<ResponseDTO<Dictionary<string, string>>> UploadFileAsync(IFormFile file, string email);
    }
}
