

using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CMS.API.Models;
using CMS.DATA.Context;
using CMS.DATA.Entities;
using CMS.MVC.Services.ServicesInterface;
using Microsoft.AspNetCore.Identity;

namespace CMS.MVC.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly CMSDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly IConfiguration _config;

        public UserService(CMSDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signinManager, IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signinManager;
            _config = config;
        }


        #region UploadFileAsync
        public async Task<UploadResponseDto<Dictionary<string, string>>> UploadFileAsync(IFormFile file, string email)
        {
            var response = new UploadResponseDto<Dictionary<string, string>>();
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    throw new ArgumentNullException(nameof(email));
                }

                var findContact = await _userManager.FindByEmailAsync(email);
                if (findContact == null)
                {
                    throw new ArgumentNullException($"User with the email {email} does not exist");
                }

                var account = new Account
                {
                    ApiKey = _config.GetSection("Cloudinary:ApiKey").Value,
                    ApiSecret = _config.GetSection("Cloudinary:ApiSecret").Value,
                    Cloud = _config.GetSection("Cloudinary:CloudName").Value

                };

                var cloudinary = new Cloudinary(account);

                if (file.Length is > 0 and <= 1024 * 1024 * 2)
                {
                    if (file.ContentType.Equals("image/jpeg") || file.ContentType.Equals("image/png") ||
                        file.ContentType.Equals("image/jpg"))
                    {
                        UploadResult uploadResult;
                        await using (var stream = file.OpenReadStream())
                        {
                            var uploadParameters = new ImageUploadParams
                            {
                                File = new FileDescription(file.FileName, stream),
                                Transformation = new Transformation().Width(300).Height(300).Crop("fill").Gravity("face")
                            };

                            uploadResult = await cloudinary.UploadAsync(uploadParameters);
                        }

                        var result = new Dictionary<string, string>
                        {
                            { "PublicId", uploadResult.PublicId },
                            { "Url", uploadResult.Url.ToString() }
                        };
                        response.Result = result;
                        response.DisplayMessage = "Image was uploaded successfully!";
                        response.StatusCode = StatusCodes.Status200OK;
                        return response;
                    }
                    else
                    {
                        response.ErrorMessages = new List<string>() { "invalid file format" };
                        response.StatusCode = StatusCodes.Status401Unauthorized;
                        return response;
                    }
                }
                else
                {
                    response.ErrorMessages = new List<string>() { "invalid file size" };
                    response.StatusCode = StatusCodes.Status401Unauthorized;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessages = new List<string>() { ex.Message };
                response.StatusCode = StatusCodes.Status401Unauthorized;
                return response;

            }
        }
        #endregion

        #region DeleteFileAsync
        public async Task<UploadResponseDto<bool>> DeleteFileAsync(string publicId, string email)
        {
            var response = new UploadResponseDto<bool>();

            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    throw new ArgumentNullException(nameof(email));
                }

                var findContact = await _userManager.FindByEmailAsync(email);
                if (findContact == null)
                {
                    throw new ArgumentNullException($"User with the email {email} does not exist");
                }

                var account = new Account
                {
                    ApiKey = _config.GetSection("Cloudinary:ApiKey").Value,
                    ApiSecret = _config.GetSection("Cloudinary:ApiSecret").Value,
                    Cloud = _config.GetSection("Cloudinary:CloudName").Value
                };

                var cloudinary = new Cloudinary(account);

                var deletionParams = new DeletionParams(publicId);

                var result = await cloudinary.DestroyAsync(deletionParams);

                if (result != null)
                {
                    response.StatusCode = StatusCodes.Status200OK;
                    response.DisplayMessage = "Image was successfully deleted";
                    response.Result = true;
                    return response;
                }
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.DisplayMessage = "Image failed to delete";
                response.Result = false;
                return response;


            }
            catch (Exception ex)
            {
                response.ErrorMessages = new List<string>() { ex.Message };
                response.StatusCode = StatusCodes.Status401Unauthorized;
                return response;
            }
        }
        #endregion

    }
}
