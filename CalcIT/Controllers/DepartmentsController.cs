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
           //using (_context)
           // {
           //     var dep = new List<Department>()
           //     {
           //              new Department {name = "Chirurgia"},
           //              new Department {name = "Pulmonologia"},
           //              new Department { name = "Ortopedia" },
           //              new Department { name = "SOR" },
           //              new Department { name = "Kardiologia" },
           //     };
           //     _context.Departmens.AddRange(dep);
           //     _context.SaveChanges();
           // }
            return _context.Departmens.ToList();
        }
        // GET: api/Departments/5
        //[HttpGet(Name = "Get_Departments")]
        //public async Task<ActionResult<IEnumerable<Department>>> Get()
        //{
        //    //using (_context)
        //    //{
        //    //    var dep = new List<Department>()
        //    //    {
        //    //             new Department {name = "Chirurgia"},
        //    //             new Department {name = "Pulmonologia"},
        //    //             new Department { name = "Ortopedia" },
        //    //             new Department { name = "SOR" },
        //    //             new Department { name = "Kardiologia" },
        //    //    };
        //    //   await _context.Departmens.AddRangeAsync(dep);
        //    //   await _context.SaveChangesAsync();
        //    //}
        //   var deps= await _context.Departmens.ToListAsync();
        //    return deps;
        //}

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
