﻿
namespace Entity
{
    public class UserCourse
    {
        public string UserEmail { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
