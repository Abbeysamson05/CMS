using CMS.DATA.Entities;

namespace CMS.MVC.ViewModels
{
    public class StudentDashBoardViewModel
    {
        public ApplicationUser User { get; set; }
        public Course course { get; set; }
    }
}
