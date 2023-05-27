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
        [StringLength(6, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string ConfirmPassword { get; set; }
    }
}
