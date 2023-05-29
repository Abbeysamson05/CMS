using Microsoft.AspNetCore.Identity;
using System.Collections;

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
<<<<<<< HEAD
=======
        public List<UserCourse> Courses { get; set; }
        public List<UserStack> Stacks { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<QuizReviewRequest> QuizReviews { get; set; }
        public List<UserQuizTaken> Quizes { get; set; }
>>>>>>> 17278b98d1f9b20d97e8c9c2c94fcf70fbff7b89
        public ICollection<UserCourse> Courses { get; set; }
        public ICollection<UserStack> Stacks { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<UserQuizTaken> Quizes { get; set; }
        public List<QuizReviewRequest> QuizReviews { get; set; }
        
<<<<<<< HEAD
=======

>>>>>>> 17278b98d1f9b20d97e8c9c2c94fcf70fbff7b89
    }
}
