using EntityLayer.Concrete.DTOs.MembershipDTOs;
using Microsoft.AspNetCore.Mvc;
using CrasProjectAPI.Services;
using EntityLayer.Concrete.TableModels.Membership;
using Microsoft.AspNetCore.Authorization;

namespace CrasProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class AccountController : ControllerBase
    {
        private readonly AccountManager _accountManager;

        public AccountController(AccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] LoginDto login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _accountManager.FindUserByEmailAsync(login.Email);
            if (user == null)
            {
                return BadRequest(new { message = "Email or Password not correct" });
            }

            var result = await _accountManager.PasswordSignInAsync(user, login.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Email or Password not correct" });
            }

            var token = await _accountManager.CreateJwtTokenAsync(user);
            return Ok(new { token });
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

            var result = await _accountManager.CreateUserAsync(user, registerDto.Password);
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
            if (!await _accountManager.RoleExistsAsync(role))
            {
                var result = await _accountManager.CreateRoleAsync(role);
                if (result.Succeeded)
                {
                    return Ok(new { message = "Role added successfully" });
                }

                return BadRequest(new { message = "Failed to add role", errors = result.Errors });
            }
            return BadRequest(new { message = "Role already exists" });
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] UserRoleDto model)
        {

            var user = await _accountManager.FindUserByIdAsync(model.UserId);
            if (user == null)
            {
                return BadRequest(new { message = "User not found" });
            }

            if (!await _accountManager.RoleExistsAsync(model.Role))
            {
                return BadRequest(new { message = "Role does not exist" });
            }

            var result = await _accountManager.AddToRoleAsync(user, model.Role);
            if (result.Succeeded)
            {
                return Ok(new { message = "Role assigned successfully" });
            }
            return BadRequest(new { message = "Failed to assign role", errors = result.Errors });
        }


        [HttpDelete("delete-role/{role}")]
        public async Task<IActionResult> DeleteRole(string role)
        {
            if (!await _accountManager.RoleExistsAsync(role))
            {
                return BadRequest(new { message = "Role does not exist" });
            }

            var result = await _accountManager.DeleteRoleAsync(role);
            if (result.Succeeded)
            {
                return Ok(new { message = "Role deleted successfully" });
            }

            return BadRequest(new { message = "Failed to delete role", errors = result.Errors });
        }

         [HttpPut("update-role")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleDto model)
        {
            if (!await _accountManager.RoleExistsAsync(model.Name))
            {
                return BadRequest(new { message = "Current role does not exist" });
            }

            var result = await _accountManager.UpdateRoleAsync(model.Name, model.NewRole);
            if (result.Succeeded)
            {
                return Ok(new { message = "Role updated successfully" });
            }

            return BadRequest(new { message = "Failed to update role", errors = result.Errors });
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetAllRole()
        {
            var roles = await _accountManager.GetAllRolesAsync();
            return Ok(roles);
        }
    }
}
