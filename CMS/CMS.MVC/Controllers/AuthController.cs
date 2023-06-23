using CMS.API.Configuration;
﻿using CMS.API.Models;
using CMS.DATA.Entities;
using CMS.MVC.Services.ServicesInterface;
using CMS.MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Xml.Linq;

namespace CMS.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IEmailServices _emailService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(IAuthService authService, IEmailServices emailService, UserManager<ApplicationUser> userManager)
        {
            _authService = authService;
            _emailService = emailService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

       
        [HttpPost("send-invite")]
        public IActionResult SendInvite(PermissionViewModel permissionViewModel)
        {
            var linkToRegister = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/account/register?stackId={HttpUtility.UrlEncode(permissionViewModel.InviteUser.StackId)}&firstName={HttpUtility.UrlEncode(permissionViewModel.InviteUser.FirstName)}&lastName={HttpUtility.UrlEncode(permissionViewModel.InviteUser.LastName)}&userType={HttpUtility.UrlEncode(permissionViewModel.InviteUser.UserType)}&email={HttpUtility.UrlEncode(permissionViewModel.InviteUser.Email)}&sqaudNumber={HttpUtility.UrlEncode(permissionViewModel.InviteUser.SquadNumber)}";


            var subject = "Invitation to Program";
            var content = $"<p>Dear {permissionViewModel.InviteUser.FirstName}, you have been invited to join the decagon program.</p><br>" +
                          $"<div><p>Please click the following link to accept the invitation:</p> " +
                          $"<a href='{linkToRegister}'>Accept Invitation</a></div>";

            var mail = new Message(new List<string>() { permissionViewModel.InviteUser.Email }, subject, content);

            try
            {
                _emailService.SendEmail(mail);

                var response = new
                {
                    statusCode = 200,
                    displayMessage = "Invitation sent successfully",
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to send invite: {ex.Message}");
            }
        }

    }
}
