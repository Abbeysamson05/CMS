
using AutoMapper;
using CMS.DATA.Context;
using CMS.DATA.Context;
using CMS.DATA.DTO;

using CMS.DATA.Entities;
using CMS.DATA.Enum;

using CMS.MVC.Services.Implementation;
using CMS.MVC.Services.ServicesInterface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace CMS.MVC.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly CMSDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly IMapper _mapper;

        public UserService(CMSDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signinManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signinManager;
            _mapper = mapper;
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

        public async Task<ResponseDto<string>> GetUserRoles(string userId)
        {
            var response = new ResponseDto<string>();
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.DisplayMessage = $"Not successful";
                    response.ErrorMessages = new List<string>() { "User not found." };
                    return response;
                }
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Any())
                {
                    string rolesString = string.Join(", ", roles);
                    response.StatusCode = StatusCodes.Status200OK;
                    response.DisplayMessage = "User roles retrieved successfully";
                    response.Result = rolesString;
                    return response;
                }
                response.StatusCode = StatusCodes.Status204NoContent;
                response.DisplayMessage = "This user has no roles ";
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.DisplayMessage = "Bad Request";
                response.ErrorMessages = new List<string>() { ex.Message };
                return response;
            }
        }

        public async Task<ResponseDto<IEnumerable<GetAllUsersDto>>> GetAllUsers()
        {
            var response = new ResponseDto<IEnumerable<GetAllUsersDto>>();
            try
            {
                var users = await _userManager.Users.ToListAsync();
                if (users == null || !users.Any())
                {
                    response.StatusCode = StatusCodes.Status204NoContent;
                    response.DisplayMessage = "No Content Found";
                    return response;
                }
                var usersDtos = _mapper.Map<IEnumerable<GetAllUsersDto>>(users);
                response.StatusCode = StatusCodes.Status200OK;
                response.DisplayMessage = "Operation Successful";
                response.Result = usersDtos;
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.DisplayMessage = "Error Occured while getting user";
                response.ErrorMessages = new List<string> { ex.Message };
                return response;

            }

        }
        public async Task<ResponseDto<GetuserByIdDto>> GetByIDAsync(string Id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(Id);
                if (user == null)
                {
                    return new ResponseDto<GetuserByIdDto>
                    {
                        StatusCode = StatusCodes.Status204NoContent,
                        DisplayMessage = $"User with ID {Id} was not found"
                    };
                }
                var userResponse = _mapper.Map<GetuserByIdDto>(user);
                return new ResponseDto<GetuserByIdDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    DisplayMessage = "Successful Operation",
                    Result = userResponse
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<GetuserByIdDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    DisplayMessage = "Error Occured while getting user",
                    ErrorMessages = new List<string> { ex.Message }
                };
            }


        }
    }

}
