using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class CourseDTO
    {
        public int Id { get; set; }

        [Required]
        public string CurseName { get; set; }
    }
}
