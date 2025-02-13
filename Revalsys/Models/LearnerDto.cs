using System.ComponentModel.DataAnnotations;

namespace Revalsys.Models
{
    public class LearnerDto
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
            
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required, MaxLength(15)]
        public string Mobile { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime DOB { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }

        public string ProfileImage { get; set; }

        [Required]
        public List<int> CourseIds { get; set; }

    }
}
