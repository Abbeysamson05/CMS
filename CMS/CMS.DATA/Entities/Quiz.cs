namespace CMS.DATA.Entities
{
    public class Quiz : BaseEntity
    {
        public string Question { get; set; }
        public string AnswerType { get; set; }
        public string PreferedAnswer { get; set; }
        public string AddedBy { get; set; }
        public string Instruction { get; set; }
        public Lesson Lesson { get; set; }
        public string LessonId { get; set; }
        public List<QuizOption> QuizOptions { get; set; }
        public List<UserQuizTaken> User { get; set; }
    }
}