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
        [StringLength(20, MinimumLength = 8, ErrorMessage = "The password must be between 8 and 20 characters.")]
        public string Password { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "The password must be between 8 and 20 characters.")]
        public string ConfirmPassword { get; set; }
    }
}
