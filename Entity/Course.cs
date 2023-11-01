using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CurseName { get; set; }

        public ICollection<UserCourse> CourseApplicationUsers { get; set; }
    }
}
