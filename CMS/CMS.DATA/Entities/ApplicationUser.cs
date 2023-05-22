using Microsoft.AspNetCore.Identity;

namespace CMS.DATA.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SquadNumber { get; set; }
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool ActiveStatus { get; set; }
        public string RefreshToken { get; set; } = String.Empty;
        public DateTime RefreshTokenExpiryTime { get; set; }
        public List<UserCourse> Courses { get; set; }
        public List<UserStack> Stacks { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<UserQuizTaken> Quizes { get; set; }
    }
}
