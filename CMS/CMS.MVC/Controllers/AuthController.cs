using CMS.API.Configuration;
using CMS.API.Models;
using CMS.MVC.Services.ServicesInterface;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Xml.Linq;

namespace CMS.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;

        public AuthController(IAuthService authService, IEmailService emailService)
        {
            _authService = authService;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }


       
        [HttpPost("send-invite")]
        public IActionResult SendInvite([FromBody] List<string> emails, string stackId, string Firstname,string Lastname)
        {
            var linkToRegister = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/adduser?stackId={HttpUtility.UrlEncode(stackId)}&Firstname={HttpUtility.UrlEncode(Firstname)}&Lastname={HttpUtility.UrlEncode(Lastname)}";

            var subject = "Invitation to Program";
            var content = $"<p>Dear {Firstname}, you have been invited to join the decagon program.</p><br>" +
                          $"<div><p>Please click the following link to accept the invitation:</p> " +
                          $"<a href='{linkToRegister}'>Accept Invitation</a></div>";

            var mail = new Message(emails, subject, content);

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
