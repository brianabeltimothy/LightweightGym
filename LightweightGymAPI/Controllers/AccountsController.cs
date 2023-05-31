using LightweightGymAPI.Entities;
using LightweightGymAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LightweightGymAPI.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace LightweightGymAPI.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountsController(UserManager<ApplicationUser> userManager, IAccountRepository accountRepository, IMapper mapper, SignInManager<ApplicationUser> signInManager)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
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

        [HttpGet("user")]
        public async Task<IActionResult> GetUserByEmail([FromQuery] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            // Return the user data
            return Ok(user);
        }



        [HttpPost("signup")]
        public async Task<ActionResult> SignUp([FromBody] ApplicationUserForSignUpDto signUp)
        {
            var result = await _accountRepository.SignUpAsync(signUp);

            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            // Error occurred during sign-up, return the error messages
            var errorMessages = result.Errors.Select(error => error.Description);
            return BadRequest(errorMessages);
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

        [HttpPost("signout")]
        [Authorize]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            return Ok();
        }
    }
}
