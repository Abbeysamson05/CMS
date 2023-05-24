﻿using System.ComponentModel.DataAnnotations;

namespace CMS.DATA.Entities
{
    public class Course : BaseEntity
    {
        [MaxLength(150)]
        public string? Name { get; set; }

        public ICollection<UserCourse> AddedBy { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
        public bool IsCompleted { get; set; }
    }
}