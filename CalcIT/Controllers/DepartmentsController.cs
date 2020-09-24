using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CalcIt.Models;
using CalcIT.Data;
using System.Security.AccessControl;
using AutoMapper.Configuration;
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
    [Authorize(Roles = "Admin, Doctor")]
    [Route("api/[controller]/[action]")]
    [Audit]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly UserContext _context;
        public DepartmentsController(UserContext context)
        {
            _context = context;
        }
        //GET: api/Departments
       [HttpGet]
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var departments = await _context.Departmens.ToListAsync();
            return departments;
        }

        // POST: api/Departments
        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] Department model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                using (_context)
                {
                    _context.Departmens.Add(new Department()
                    {
                        name = model.name,
                    });

                    await _context.SaveChangesAsync();
                };
                return Ok("Department's been added");
            }
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
