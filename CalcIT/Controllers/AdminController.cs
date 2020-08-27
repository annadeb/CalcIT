using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using CalcIT.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalcIT.Controllers
{
    
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            //var naFlag = _roleManager.RoleExistsAsync("NotActive").Result;
            //if (!naFlag)
            //{
            //    var notactive = new IdentityRole();
            //    notactive.Name = "NotActive";
            //    _roleManager.CreateAsync(notactive);
            //}
            //var aFlag = _roleManager.RoleExistsAsync("Admin").Result;
            //if (!aFlag)
            //{
            //    var admin = new IdentityRole();
            //    admin.Name = "Admin";
            //    _roleManager.CreateAsync(admin);
            //}
            //var dFlag = _roleManager.RoleExistsAsync("Doctor").Result;
            //if (!dFlag)
            //{
            //    var doctor = new IdentityRole();
            //    doctor.Name = "Doctor";
            //    _roleManager.CreateAsync(doctor);
            //}
        }

        [HttpGet]
        public async Task<object> GetUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        [HttpGet]
        public async Task<object> GetUserRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("Such user doesn't exist");    
            }
            var roles =  _userManager.GetRolesAsync(user);
            var userrole = new
            {
               user,
               roles
            };
            return Ok(userrole);
        }
        [HttpPost]
        public async Task<object> SpecifyUserRole(string userId,string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("Such user doesn't exist");
            }
            var ifRoleExists = _roleManager.RoleExistsAsync(role);
            if (!ifRoleExists.Result)
            {
                return NotFound("Such role doesn't exist");
            }
            await _userManager.AddToRoleAsync(user, role);
            return Ok("Role's been added to the user");
        }
    }
}