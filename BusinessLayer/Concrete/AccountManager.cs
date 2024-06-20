using CoreLayer.Tools;
using EntityLayer.Concrete.DTOs.MembershipDTOs;
using EntityLayer.Concrete.TableModels.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CrasProjectAPI.Services
{
    public class AccountManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountManager(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<ApplicationUser?> FindUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<SignInResult> PasswordSignInAsync(ApplicationUser user, string password)
        {
            return await _signInManager.PasswordSignInAsync(user, password, false, false);
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IList<string>> GetUserRolesAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<string> CreateJwtTokenAsync(ApplicationUser user)
        {
            var userRoles = await GetUserRolesAsync(user);
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
            return tokenHandler.WriteToken(token);
        }

        public async Task<IdentityResult> CreateRoleAsync(string role)
        {
            return await _roleManager.CreateAsync(new ApplicationRole { Name = role });
        }

        public async Task<bool> RoleExistsAsync(string role)
        {
            return await _roleManager.RoleExistsAsync(role);
        }

        public async Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<ApplicationUser?> FindUserByIdAsync(int userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }
        public async Task<IdentityResult> DeleteRoleAsync(string role)
        {
            var applicationRole = await _roleManager.FindByNameAsync(role);
            if (applicationRole != null)
            {
                return await _roleManager.DeleteAsync(applicationRole);
            }

            return IdentityResult.Failed(new IdentityError { Description = $"Role {role} not found" });
        }

        public async Task<IdentityResult> UpdateRoleAsync(string currentRole, string newRole)
        {
            var applicationRole = await _roleManager.FindByNameAsync(currentRole);
            if (applicationRole != null)
            {
                applicationRole.Name = newRole;
                return await _roleManager.UpdateAsync(applicationRole);
            }

            return IdentityResult.Failed(new IdentityError { Description = $"Role {currentRole} not found" });
        }
        public async Task<List<string>> GetAllRolesAsync()
        {
            return await _roleManager.Roles.Select(r => r.Name).ToListAsync();
        }
    }
}
