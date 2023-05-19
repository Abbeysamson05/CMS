using System;
using Microsoft.AspNetCore.Identity;

namespace CMS.DATA.Entities
{
	public class ApplicationUser:IdentityUser
	{
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}

