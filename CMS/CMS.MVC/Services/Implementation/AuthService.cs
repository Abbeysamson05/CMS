using CMS.DATA.Context; 
using CMS.DATA.DTO;
using CMS.DATA.Entities;
using CMS.MVC.Services.ServicesInterface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMS.MVC.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly CMSDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        //private readonly IMapper _mapper;

        public AuthService(CMSDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signinManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signinManager;
            
        }

        public async Task<ResponseDto<ResetPassword>> ResetPasswords(ResetPassword resetPassword)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(resetPassword.Email);
                if (user == null)
                {
                    var response = new ResponseDto<ResetPassword>
                    {
                        StatusCode = 404,
                        DisplayMessage = "User not found",
                        Result = null,
                        ErrorMessages = new List<string> { "The user with the specified email address was not found" }
                    };
                    return response;
                }

                var resetResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);

                if (resetResult.Succeeded)
                {
                    var response = new ResponseDto<ResetPassword>
                    {
                        StatusCode = 200,
                        DisplayMessage = "Password reset successful",
                        Result = resetPassword,
                        ErrorMessages = null
                    };
                    return response;
                }
                else
                {
                    var response = new ResponseDto<ResetPassword>
                    {
                        StatusCode = 500,
                        DisplayMessage = "Password reset failed",
                        Result = null,
                        ErrorMessages = new List<string> { "An error occurred while resetting the password" }
                    };
                    return response;
                }

            }
            catch (Exception ex)
            {
                var response = new ResponseDto<ResetPassword>
                {
                    StatusCode = 500,
                    DisplayMessage = "Internal Server Error",
                    Result = null,
                    ErrorMessages = new List<string> { $"{ex.Message}", "An error occurred while resetting the password" }
                };
                return response;
            }
        }

        public async Task<ResponseDto<ConfirmEmailDto>>ConfirmEmail(string useremail, string token)
        {
            try
            {
                if (string.IsNullOrEmpty(useremail) || string.IsNullOrEmpty(token))
                {
                    var response = new ResponseDto<ConfirmEmailDto>
                    {
                        StatusCode = 400,
                        DisplayMessage = "Bad Request",
                        Result = null,
                        ErrorMessages = new List<string> { "User ID and token must be provided" }
                    };
                    return response;
                }
                
                var user = await _userManager.FindByEmailAsync(useremail);
                if (user == null)
                {
                    var response = new ResponseDto<ConfirmEmailDto>
                    {
                        StatusCode = 404,
                        DisplayMessage = "User not found",
                        Result = null,
                        ErrorMessages = new List<string> { "The user with the specified ID was not found" }
                    };
                    return response;
                }
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    var response = new ResponseDto<ConfirmEmailDto>
                    {
                        StatusCode = 200,
                        DisplayMessage = "Email confirmed successfully",
                        Result = {},
                        ErrorMessages = ""
                    };
                    return response;
                }
                    else
                    {
                        var response = new ResponseDto<ConfirmEmailDto>
                        {
                            StatusCode = 400,
                            DisplayMessage = "Email confirmation failed",
                            Result = null,
                            ErrorMessages = result.Errors.Select(e => e.Description).ToList()
                        };
                        return response;
                    }
                
            }
            catch (Exception ex)
            {
                var response = new ResponseDto<ConfirmEmailDto>
                {
                    StatusCode = 500,
                    DisplayMessage = "Internal Server Error",
                    Result = null,
                    ErrorMessages = new List<string> {  "An error occurred while resetting the password" }
                };
                return response;

            }
        }
    }
}
