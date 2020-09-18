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

        public IEnumerable<Department> Get()
        {   
            return _context.Departmens.ToList();
        }

        // POST: api/Departments
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
