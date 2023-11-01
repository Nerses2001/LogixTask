
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [MinLength(3, ErrorMessage = "First Name should be at least 3 characters.")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Last Name should be at least 3 characters.")]
        public string LastName { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "Invalid phone number format. Use (999) 999-9999.")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        [NotMapped]
        public string FormattedAddress { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        public ICollection<UserCourse> UserCourses { get; set; } = new List<UserCourse>();
        public string AccessToken {  get; set; }

    }
}
