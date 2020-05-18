using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalcIt.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalcIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        // GET: api/Departments
        [HttpGet]

        public IEnumerable<Department> Get()
        {
            List<Department> departments = new List<Department>{
            new Department(){department_id=1, name="Chirurgia" },
            new Department(){department_id=2, name="Zakaźny" },
            new Department(){department_id=3, name="Pulmonologia" },
           };
            return departments;
        }

        // GET: api/Departments/5
        [HttpGet("{id}", Name = "Get_Departments")]
        public string Get(int id)
        {
            return "value";
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
