using EntityLayer.Concrete.DTOs.MembershipDTOs;
using EntityLayer.Concrete.TableModels.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CrasProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LogIn(LoginDto login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null)
            {
                return BadRequest("Email Or Password not correct");
            }

            var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);

            if (result.Succeeded)
            {
                return Ok("Success");
            }

            return BadRequest("error");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser
            {
                Name = registerDto.Name,
                UserName = registerDto.UserName,
                Surname = registerDto.Surname,
                Email = registerDto.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                return Ok("Success");
            }

            var errors = result.Errors;
            foreach (var error in errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }
    }
}
