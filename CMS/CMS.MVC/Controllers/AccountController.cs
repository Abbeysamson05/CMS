using CMS.API.Configuration;
using CMS.DATA.Context;
using CMS.DATA.Entities;
using CMS.DATA.Enum;
using CMS.MVC.Services.ServicesInterface;
using CMS.MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Web;

namespace CMS.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly CMSDbContext _context;
        private readonly IEmailServices _emailService;
        private readonly IUserService userService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, CMSDbContext context, IEmailServices emailService, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _emailService = emailService;
            this.userService = userService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (_signInManager.IsSignedIn(User))
            {
                RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("Invalid Credentials", "Email not recognised!");
                    return View(model);
                }
                //var checkpassword = await _signInManager.CheckPasswordSignInAsync(user, model.Password, true);
                var loginResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);

                var getUserInRole = await _userManager.GetRolesAsync(user);
                if (getUserInRole.Contains("Facilitator"))
                {
                    return RedirectToAction("FacilitatorDashboard", "Dashboard");
                }
                else if (getUserInRole.Contains("Decadev"))
                {
                    return RedirectToAction("StudentDashboard", "Dashboard", new { userid = user.Id, gencourseid = "null" });
                }
                else
                {
                    return RedirectToAction("PermissionDecadev", "Account");
                }

            }
            ModelState.AddModelError("Invalid Credentials", "Password not recognised!");
            return View(model);
        }
        public IActionResult FacilitatorLogin()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register(string stackId, string firstName, string lastName, string userType, string email, string sqaudNumber)
        {
            var user = new RegisterViewModel();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.StackId = stackId;
            user.Email = email;
            user.UserType = userType;
            user.SquadNo = sqaudNumber;
            return View(user);
        }
        public IActionResult RedirectTo(IList<string> roles, string userId)
        {
            foreach (var role in roles)
            {
                if (role.ToLower() == "decadev")
                {
                    return RedirectToAction("StudentDashboard", "Dashboard", new { userid = userId });

                }
                else if (role.ToLower() == "facilitator")
                {
                    return RedirectToAction("FacilitatorDashboard", "Dashboard");
                }
                else
                {
                    return RedirectToAction("FacilitatorDashboard", "Dashboard");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            IList<string> UserRoles = new List<string>();
            if (_signInManager.IsSignedIn(User))
            {

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var getUser = await _userManager.FindByIdAsync(userId);
                UserRoles = await _userManager.GetRolesAsync(getUser);
                this.RedirectTo(UserRoles, getUser.Id);
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    ModelState.AddModelError("Invalid email", "Email already exists");
                    return View(model);
                }

                var userToAdd = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.FirstName + model.LastName,
                    SquadNumber = model.SquadNo,
                    PublicId = string.Empty,
                    ImageUrl = string.Empty,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow,
                    Email = model.Email
                };

                var addUserResult = await _userManager.CreateAsync(userToAdd, model.Password);
                var userStack = new UserStack();
                userStack.StackId = model.StackId;
                userStack.UserId = userToAdd.Id;
                var addUserStack = await _context.UserStack.AddAsync(userStack);
                await _context.SaveChangesAsync();
                if (addUserResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(userToAdd, model.UserType);

                    if (model.StackId == ".Net")
                    {
                        await _userManager.AddClaimAsync(userToAdd, new Claim(Permissions.can_access_dotnet_curriculum.ToString(), true.ToString()));
                    }
                    else if (model.StackId == "Node")
                    {
                        await _userManager.AddClaimAsync(userToAdd, new Claim(Permissions.can_access_node_curriculum.ToString(), true.ToString()));
                    }
                    else
                    {
                        await _userManager.AddClaimAsync(userToAdd, new Claim(Permissions.can_access_java_curriculum.ToString(), true.ToString()));
                    }
                    
                    var result = await _signInManager.PasswordSignInAsync(userToAdd, model.Password, false, true);
                    var getUser = await _userManager.FindByEmailAsync(model.Email);
                    var UserRole = await _userManager.GetRolesAsync(getUser);
                    foreach (var role in UserRole)
                    {
                        if (role.ToLower() == "decadev")
                        {
                            return RedirectToAction("StudentDashboard", "Dashboard", new { userid = getUser.Id, gencourseid = "null" });

                        }
                        else if (role.ToLower() == "facilitator")
                        {
                            return RedirectToAction("FacilitatorDashboard", "Dashboard");
                        }
                        else
                        {
                            return RedirectToAction("PermissionDecadev", "Account");
                        }

                    }
                }

                foreach (var err in addUserResult.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ResetPasword(string token, string email)
        {
            var model = new ResetPasswordViewModel();
            model.Token = token;
            model.Email = email;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("NotFound", $"User with email:{model.Email} was not found!");
                    return View(model);
                }

                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }

                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }

            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                var link = string.Empty;
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    link = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/account/resetpasword?token={HttpUtility.UrlEncode(token)}&email={HttpUtility.UrlEncode(model.Email)}";
                }
                var Message = new Message(new List<string>() { model.Email }, "Reset Password Code", $"<p>To reset your password <a href ='{link}'>click here</a>");
                _emailService.SendEmail(Message);
              
            }

            return View(model);
        }

        public IActionResult ConfirmPassword()
        {
            return View();
        }
        [HttpGet]
        [Route("account/delete/dev/{id}")]
        public async Task<IActionResult> DeleteDev(string id)
        {
            var getuser = await _userManager.FindByIdAsync(id);
           var removeUserFromStack = await _context.UserStack.FirstOrDefaultAsync(e=>e.UserId == getuser.Id); 
           if (removeUserFromStack != null) { 
            _context.Remove(removeUserFromStack);
            await _context.SaveChangesAsync();
            }
            var deleteDev = await _userManager.DeleteAsync(getuser);        
            return RedirectToAction("PermissionDecadev", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> PermissionDecadev()
        {
            var user = new List<PermittedUser>();
            var model = new PermissionViewModel();
            var results = await _context.Users
    .Join(
        _context.UserStack,
        user => user.Id,
        userStack => userStack.UserId,
        (user, userStack) => new { User = user, UserStack = userStack })
    .Join(
        _context.Stacks,
        userStack => userStack.UserStack.StackId,
        stack => stack.Id,
        (userStack, stack) => new { User = userStack.User, Stack = stack }).ToListAsync();

           
            foreach (var dev in results)
            {
                var newDev = new PermittedUser { Id = dev.User.Id, Email = dev.User.Email, Language = dev.Stack.StackName, Name = dev.User.FirstName + " " + dev.User.LastName };
                user.Add(newDev);
            }
            model.PermittedUsers = user;
            return View(model);
        }

        public IActionResult PermissionFacilitator()
        {
            return View();
        }
        [Route("account/uploadpicture/{email}")]
        [HttpGet]
        public IActionResult UploadPicture(string email)
        {
            var model = new UploadPictureViewModel { Email = email };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UploadPicture(UploadPictureViewModel model)
        {
            var upload = await userService.UploadFileAsync(model.ImageFile, model.Email);

            if (upload.StatusCode == 200)
            {
                var getUser= await _userManager.FindByEmailAsync(model.Email);
                return RedirectToAction("StudentDashboard", "Dashboard", new { userid = getUser.Id, gencourseid = "null" });
            }
            return View(model);
        }
        public IActionResult SuccessInvite()
        {
            return View();
        }
    }
}
