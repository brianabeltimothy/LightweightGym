using LightweightGymAPI.Entities;
using LightweightGymAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LightweightGymAPI.Dto;

namespace LightweightGymAPI.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountsController(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetAll()
        {
            var users = await _accountRepository.GetAllAsync();

            if (users == null)
            {
                return NotFound();
            }

            var userDtos = _mapper.Map<IEnumerable<ApplicationUser>>(users);
            return Ok(userDtos);
        }


        [HttpPost("signup")]
        public async Task<ActionResult<IdentityResult>> SignUp([FromBody] ApplicationUserForSignUpDto signUp)
        {
            var result = await _accountRepository.SignUpAsync(signUp);

            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized();
        }

        [HttpPost("signin")]
        public async Task<ActionResult<bool>> SignIn([FromBody] ApplicationUserForSignInDto signIn)
        {


            var success = await _accountRepository.SignInAsync(signIn);

            if (success)
            {
                return Ok(success);
            }

            return Unauthorized();
        }

    }
}
