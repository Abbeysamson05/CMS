using System.ComponentModel.DataAnnotations;

namespace CMS.DATA.Entities
{
    public class Course : BaseEntity
    {
        [MaxLength(150)]
        public string? Name { get; set; }

        public List<UserCourse> AddedBy { get; set; }

        public List<Lesson> Lessons { get; set; }
    }
}