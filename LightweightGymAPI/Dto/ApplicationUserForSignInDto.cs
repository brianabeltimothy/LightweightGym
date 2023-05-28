using System.ComponentModel.DataAnnotations;

namespace LightweightGymAPI.Dto
{
    public class ApplicationUserForSignInDto
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "The password must be between 8 and 20 characters.")]
        public string Password { get; set; }
    }
}
