using System.ComponentModel.DataAnnotations;

namespace CMS.DATA.Entities
{
    public class Course : BaseEntity
    {
        [MaxLength(150)]
        public string? Name { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public bool IsCompleted { get; set; }
<<<<<<< HEAD


        public string AddedBy { get; set; }

        

=======
        public List<UserCourse> AddedBy { get; set; }

        public List<Lesson> Lessons { get; set; }
        public bool IsCompleted { get; set; }
>>>>>>> 17278b98d1f9b20d97e8c9c2c94fcf70fbff7b89
    }
}