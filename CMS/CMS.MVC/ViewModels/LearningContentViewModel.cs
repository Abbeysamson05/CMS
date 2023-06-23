using CMS.DATA.Entities;

namespace CMS.MVC.ViewModels
{
    public class LearningContentViewModel
    {
        public Lesson Lesson { get; set; }
        public Course Course { get; set; }
        public IEnumerable<Quiz> Quizs { get; set; }
    }
}
