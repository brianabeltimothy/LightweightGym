using LightweightGymAPI.Dto;
using LightweightGymAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LightweightGymAPI.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

        public async Task<bool> SignInAsync(ApplicationUserForSignInDto signIn)
        {
            var result = await _signInManager.PasswordSignInAsync(signIn.Email, signIn.Password, isPersistent: false, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }
    }
}
