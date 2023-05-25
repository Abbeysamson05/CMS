using CMS.DATA.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DATA.DTO
{
    public class LessonResponseDTO
    {
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string AddedById { get; set; }
        public Modules Module { get; set; }
        public ModuleWeeks Weeks { get; set; }
        [MaxLength(150)]
        public string Topic { get; set; }
        public string Text { get; set; }
        public string VideoUrl { get; set; }
        public string PublicId { get; set; }
        public bool CompletionStatus { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
