using LightweightGymAPI.Dto;
using LightweightGymAPI.Entities;
using Microsoft.AspNetCore.Identity;

namespace LightweightGymAPI.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(ApplicationUserForSignUpDto signUp);
    }
}
