using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using CalcIt.Models;
using CalcIT.Data;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CalcIT.Controllers.AuditController;

namespace CalcIT.Controllers
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin")]
    [Audit]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserContext _context;
        public AdminController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            UserContext context
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
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
            var roles = _userManager.GetRolesAsync(user);
            var userrole = new
            {
                user,
                roles
            };
            return Ok(userrole);
        }
        [HttpPost]
        public async Task<object> SpecifyUserRole(string userId, string role)
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
            await _userManager.RemoveFromRoleAsync(user, "NotActive");
            await _userManager.AddToRoleAsync(user, role);
            return Ok("Role's been added to the user");
        }
        [HttpGet]
        public async Task<IEnumerable<AuditTrail>> GetFullAudit()
        {
            return await _context.AuditTrails.ToListAsync();
        }
        [HttpGet]
        public async Task<IActionResult> GetUsersAudit(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var auditTrails = _context.AuditTrails.Where(x => x.user_id == userId);
                return Ok(auditTrails);
            }
            return NotFound("User not found");
        }

    }
}