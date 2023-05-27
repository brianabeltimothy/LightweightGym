using System.ComponentModel.DataAnnotations;

namespace LightweightGymAPI.Dto
{
    public class ApplicationUserForSignInDto
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
