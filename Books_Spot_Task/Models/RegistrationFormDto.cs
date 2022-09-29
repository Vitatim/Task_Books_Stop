using System.ComponentModel.DataAnnotations;

namespace Books_Spot_Task.Models
{
    public class RegistrationFormDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string? Password { get; set; }

        public RegistrationFormDto()
        {

        }
    }
}
