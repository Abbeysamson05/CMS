using CMS.DATA.Entities;

namespace CMS.MVC.ViewModels
{
    public class QuizPageViewModel
    {
        public IEnumerable<Lesson> Lesson { get; set; }
       
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public Quiz Quiz { get; set; }

    }
}
