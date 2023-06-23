using System.Security.Claims;

namespace CMS.MVC.Models
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetClaimValue(this ClaimsPrincipal principal, string claimType)
        {
            var claim = principal.FindFirst(claimType);
            return claim?.Value;
        }
    }
}
