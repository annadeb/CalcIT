using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
using CalcIt.Models;

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
        private readonly UserContext _context;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration, UserContext context
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;

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

            return NotFound("Login or password are wrong");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Register([FromForm] RegisterDto model)
        {

            var ifUserExist = _userManager.FindByEmailAsync(model.Email);
            if (ifUserExist != null)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "NotActive");
                    await _signInManager.SignInAsync(user, false);
                    return await GenerateJwtToken(model.Email, user);
                }
                else
                {
                    return BadRequest("Failed to create user");
                }
            }
            // throw new ApplicationException("User already exists");
            return BadRequest("User already exists");
        }

        private async Task<object> GenerateJwtToken(string email, ApplicationUser user)
        {

            var roles = await _userManager.GetRolesAsync(user);
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

        [HttpPost]
        public async Task<IActionResult> SeedDatabase()
        {
            var naFlag = _roleManager.RoleExistsAsync("NotActive").Result;
            if (!naFlag)
            {
                var notactive = new IdentityRole();
                notactive.Name = "NotActive";
                await _roleManager.CreateAsync(notactive);
            }
            var aFlag = _roleManager.RoleExistsAsync("Admin").Result;
            if (!aFlag)
            {
                var admin = new IdentityRole();
                admin.Name = "Admin";
                await _roleManager.CreateAsync(admin);
            }
            var dFlag = _roleManager.RoleExistsAsync("Doctor").Result;
            if (!dFlag)
            {
                var doctor = new IdentityRole();
                doctor.Name = "Doctor";
                await _roleManager.CreateAsync(doctor);
            }
            var dep = new List<Department>()
                {
                         new Department {name = "Chirurgia"},
                         new Department {name = "Pulmonologia"},
                         new Department { name = "Ortopedia" },
                         new Department { name = "SOR" },
                         new Department { name = "Kardiologia" },
                };
            await _context.Departmens.AddRangeAsync(dep);

            var pat = new List<Patient>()
            {
             new Patient {name = "Janek", surname="Kowalski", PESEL=97072058336, department_id=1, birthdate=DateTime.Parse("20.07.1997"), height=178, registration_date=DateTime.Now.AddDays(-1), weight=78.5},
             new Patient {name = "Klaudia", surname="Rózia", PESEL=98042158354, department_id=3, birthdate=DateTime.Parse("21.04.1998"), height=180, registration_date=DateTime.Now.AddDays(-5), weight=68.5},
             new Patient {name = "Joanna", surname="Czujek", PESEL=92042058386, department_id=2, birthdate=DateTime.Parse("20.04.1992"), height=161, registration_date=DateTime.Now.AddDays(-10), weight=55},
             new Patient {name = "Marian", surname="Zuber", PESEL=95052058323, department_id=2, birthdate=DateTime.Parse("20.05.1995"), height=175, registration_date=DateTime.Now.AddDays(-3), weight=73.5},
             new Patient {name = "Michał", surname="Cose", PESEL=91052758335, department_id=1, birthdate=DateTime.Parse("27.05.1991"), height=185, registration_date=DateTime.Now.AddDays(-2), weight=83.5},
             new Patient {name = "Michał", surname="Barłoś", PESEL=96102058336, department_id=3, birthdate=DateTime.Parse("20.10.1996"), height=182, registration_date=DateTime.Now.AddDays(-7), weight=94},
             new Patient {name = "Halina", surname="Jeżyna", PESEL=95051058336, department_id=1, birthdate=DateTime.Parse("10.05.1995"), height=165, registration_date=DateTime.Now, weight=52.1},
             new Patient {name = "Marcin", surname="Wariacin", PESEL=85052058336, department_id=1, birthdate=DateTime.Parse("20.05.1985"), height=195, registration_date=DateTime.Now.AddDays(1), weight=97.5},
             new Patient {name = "Ola", surname="Dziubol", PESEL=99051858231, department_id=2, birthdate=DateTime.Parse("18.05.1999"), height=154, registration_date=DateTime.Now.AddDays(1), weight=49.5},
             new Patient {name = "Kot", surname="Miałczyn Drappke", PESEL=53050158336, department_id=3, birthdate=DateTime.Parse("01.05.1953"), height=180, registration_date=DateTime.Now.AddDays(-3), weight=73.5},
             new Patient {name = "Oliwia", surname="Sprawiedliwia", PESEL=64050118336, department_id=3, birthdate=DateTime.Parse("11.05.1964"), height=158, registration_date=DateTime.Now.AddDays(1), weight=58},
             new Patient {name = "Kamil", surname="Marcinkiewicz", PESEL=94050708336, department_id=2, birthdate=DateTime.Parse("07.05.1994"), height=184, registration_date=DateTime.Now.AddDays(-2), weight=85}
            };
            _context.Patients.AddRange(pat);

            //var calc = new List<Calculation>()
            //{
            // new Calculation {calculation_date=DateTime.Parse("2019-08-07"),calculation_type="BMI",calculation_data="weight=56;height=1.66",patient_id=1,doctor_id=1,result="BMI=21.6" },
            // new Calculation {calculation_date=DateTime.Today,calculation_type="BMI",calculation_data="weight=46;height=1.66",patient_id=1,doctor_id=1,result="18.6" },
            // new Calculation {calculation_date=DateTime.Today,calculation_type="Kalkulator ciąży",calculation_data="date=20-05-2020;lenght=28",patient_id=1,doctor_id=1,result="date=02-02-2021" }
            //};
            //_context.Calculations.AddRange(calc);

            await _context.SaveChangesAsync();
            return Ok("Database seeded succesfully");
        }
    }
}