using System.ComponentModel.DataAnnotations;

namespace LightweightGymAPI.Dto
{
    public class ApplicationUserForSignUpDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Compare("ConfirmPassword")]
        [StringLength(8, MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string ConfirmPassword { get; set; }
    }
}
