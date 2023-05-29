using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CMS.DATA.Context;
using CMS.DATA.Entities;
using CMS.DATA.Enum;
using CMS.DATA.DTO;
using CMS.MVC.Services.ServicesInterface;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace CMS.MVC.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;

        public UserService(UserManager<ApplicationUser> userManager,IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        public async Task<bool> GrantPermission(string userId, Permissions claims)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var newClaim = new Claim(claims.ToString(), claims.ToString());

            var result = await _userManager.AddClaimAsync(user, newClaim);

            if (!result.Succeeded)
            {
                throw new Exception("Failed to request permission.");
            }
            return true;
        }

        public async Task<bool> RequestPermission(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var existingClaims = await _userManager.GetClaimsAsync(user);
            if (existingClaims != null)
            {
                foreach (var usersClaim in existingClaims)
                {
                    await _userManager.RemoveClaimAsync(user, usersClaim);
                }

            }
            var newClaim = new Claim(Permissions.can_update.ToString(), Permissions.can_update.ToString());
            var result = await _userManager.AddClaimAsync(user, newClaim);

            if (!result.Succeeded)
            {
                throw new Exception("Failed to request permission.");
            }
            return true;
        }


        #region UploadFileAsync
        public async Task<ResponseDTO<Dictionary<string, string>>> UploadFileAsync(IFormFile file, string email)
        {
            var response = new ResponseDTO<Dictionary<string, string>>();
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
        public async Task<ResponseDTO<bool>> DeleteFileAsync(string publicId, string email)
        {
            var response = new ResponseDTO<bool>();

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
