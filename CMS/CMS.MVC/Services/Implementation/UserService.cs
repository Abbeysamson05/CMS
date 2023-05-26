//using AutoMapper;
using CMS.DATA.Context;
using CMS.DATA.DTO;
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
       

        public UserService(CMSDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signinManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signinManager;
            
        }

        public async Task<ResponseDto<bool>> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ResponseDto<bool>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    DisplayMessage = "User not found",
                    ErrorMessages = new List<string> { "User not found" }
                };
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errorMessages = result.Errors.Select(e => e.Description).ToList();
                return new ResponseDto<bool>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    DisplayMessage = "Failed to delete user",
                    ErrorMessages = errorMessages
                };
            }

            return new ResponseDto<bool>
            {
                StatusCode = StatusCodes.Status200OK,
                DisplayMessage = "User deleted successfully",
                Result = true
            };
        }

        public async Task<ResponseDto<bool>> SetActiveStatus(string userId, bool status)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ResponseDto<bool>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    DisplayMessage = "User not found",
                    ErrorMessages = new List<string> { "User not found" }
                };
            }

            user.ActiveStatus = status;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                var errorMessages = result.Errors.Select(e => e.Description).ToList();
                return new ResponseDto<bool>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    DisplayMessage = "Failed to update active status",
                    ErrorMessages = errorMessages
                };
            }

            return new ResponseDto<bool>
            {
                StatusCode = StatusCodes.Status200OK,
                DisplayMessage = "Active status updated successfully",
                Result = true
            };
        }

    }
}
