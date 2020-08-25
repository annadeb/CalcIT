using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CalcIT.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CalcIT.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : Controller
    {

        
            private readonly SignInManager<ApplicationUser> _signInManager;
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly IConfiguration _configuration;

            public AccountController(
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager,
                RoleManager<IdentityRole> roleManager,
                IConfiguration configuration
                )
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _roleManager = roleManager;
                _configuration = configuration;
            }
            [AllowAnonymous]
            [HttpPost]
            public async Task<object> Login([FromForm] LoginDto model)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
               
                if (result.Succeeded)
                {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                 return await GenerateJwtToken(model.Email, appUser);
                }
             

                throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
            }
        [AllowAnonymous]
        [HttpPost]
            public async Task<object> Register([FromForm] RegisterDto model)
            {
            var ifUserExist = _userManager.FindByEmailAsync(model.Email);
            if (ifUserExist!=null)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };
            
                var result = await _userManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                    await _signInManager.SignInAsync(user, false);
                    return await GenerateJwtToken(model.Email, user);
                }
            }
            throw new ApplicationException("User already exists");
            }

            private async Task<object> GenerateJwtToken(string email, ApplicationUser user)
            {

             var  roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
                //new Claim(ClaimTypes.Role,roles.SingleOrDefault())
            };
            for (int i = 0; i < roles.Count; i++)
            {
                claims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:JwtKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:JwtExpireDays"]));

                var token = new JwtSecurityToken(
                    _configuration["Jwt:JwtIssuer"],
                    _configuration["Jwt:JwtIssuer"],
                    claims,
                    expires: expires,
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            public class LoginDto
            {
                [Required]
                public string Email { get; set; }

                [Required]
                public string Password { get; set; }

            }

            public class RegisterDto
            {
                [Required]
                public string Email { get; set; }

                [Required]
                [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
                public string Password { get; set; }
            }
        }
}