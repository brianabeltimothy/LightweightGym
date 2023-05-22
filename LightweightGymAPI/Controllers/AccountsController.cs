using LightweightGymAPI.Entities;
using LightweightGymAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LightweightGymAPI.Dto;

namespace LightweightGymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountsController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<IdentityResult>> SignUp([FromBody] ApplicationUserForSignUpDto signUp)
        {
            var result = await _accountRepository.SignUpAsync(signUp);

            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized();
        }

    }
}
