using CoreLayer.Tools;
using EntityLayer.Concrete.DTOs.MembershipDTOs;
using EntityLayer.Concrete.TableModels.Membership;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CrasProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] LoginDto login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                return BadRequest(new { message = "Email or Password not correct" });
            }

            var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Email or Password not correct" });
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = new JwtSecurityToken(
                issuer: JwtTokenDefaults.ValidIssuer,
                audience: JwtTokenDefaults.ValidAudience,
                expires: DateTime.UtcNow.AddMinutes(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
                    SecurityAlgorithms.HmacSha256)
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.WriteToken(token);

            return Ok(new { token = jwtToken });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
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
                return Ok(new { message = "Registration successful" });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole([FromBody] string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                var result = await _roleManager.CreateAsync(new ApplicationRole { Name = role });
                if (result.Succeeded)
                {
                    return Ok(new { message = "Role added successfully" });
                }
                return BadRequest(new { message = "Failed to add role", errors = result.Errors });
            }
            return BadRequest(new { message = "Role already exists" });
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] ApplicationUserRole model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest(new { message = "User not found" });
            }

            var result = await _userManager.AddToRoleAsync(user, model.Role);
            if (result.Succeeded)
            {
                return Ok(new { message = "Role assigned successfully" });
            }
            return BadRequest(new { message = "Failed to assign role", errors = result.Errors });
        }
    }
}
