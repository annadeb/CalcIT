using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalcIt.Models;
using CalcIT.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalcIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        // GET: api/Patients
        private readonly UserContext _context;
        public PatientsController(UserContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            //var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
            //optionsBuilder.UseSqlServer("Data Source=CalcIt.db");
          

            //using (_context)
            //{
            //    var pat = new Patient() { name = "Janek", surname="Kowalski", PESEL=97072058336, department_id=1, birthdate=DateTime.Parse("20.07.1997"), height=178, registration_date=DateTime.Now, weight=78.5};

            //    _context.Patients.Add(pat);
            //    _context.SaveChanges();
            //}

            List<Patient> patients = new List<Patient>{
            new Patient(){patient_id=1, department_id=1, PESEL=123213123, name="Jan", surname="Kowalski" },
            new Patient(){patient_id=2, department_id=2, PESEL=432432432, name="Adam", surname="Mickiewicz" },
            new Patient(){patient_id=3, department_id=3, PESEL=324324433, name="Juliusz", surname="Słowacki" }
           };
            return patients;
        }

        // GET: api/Patients/5
        [HttpGet("{id}", Name = "Get_Patients")]
        public IEnumerable<Patient> Get(int id)
        {
            List<Patient> patients = new List<Patient>{
            new Patient(){patient_id=1, department_id=1, PESEL=123213123, name="Jan", surname="Kowalski" },
            new Patient(){patient_id=2, department_id=2, PESEL=432432432, name="Adam", surname="Mickiewicz" },
            new Patient(){patient_id=3, department_id=3, PESEL=324324433, name="Juliusz", surname="Słowacki" }
           };
            return patients.Where(pat=>pat.department_id==id);
        }

        // POST: api/Patients
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Patients/5
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
