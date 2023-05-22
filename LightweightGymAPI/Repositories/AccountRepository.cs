using LightweightGymAPI.Dto;
using LightweightGymAPI.Entities;
using Microsoft.AspNetCore.Identity;

namespace LightweightGymAPI.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> SignUpAsync(ApplicationUserForSignUpDto signUp)
        {
            var user = new ApplicationUser()
            {
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                Email = signUp.Email,
                UserName = signUp.Email
            };

            return await _userManager.CreateAsync(user, signUp.Password);
        }
    }
}
