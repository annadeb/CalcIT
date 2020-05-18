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
        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
            optionsBuilder.UseSqlServer("Data Source=CalcIt.db");

            using (var ctx = new UserContext(optionsBuilder.Options))
            {
                var pat = new Patient() { name = "Janek", surname="Kowalski", PESEL=97072058336, departament_id=1, birthdate=DateTime.Parse("20.07.1997"), height=178, registration_date=DateTime.Now, weight=78.5};

                ctx.Patients.Add(pat);
                ctx.SaveChanges();
            }

            List<Patient> patients = new List<Patient>{
            new Patient(){patient_id=1, PESEL=123213123, name="Jan", surname="Kowalski" },
            new Patient(){patient_id=2, PESEL=432432432, name="Adam", surname="Mickiewicz" },
            new Patient(){patient_id=3, PESEL=324324433, name="Juliusz", surname="Słowacki" }
           };
            return patients;
        }

        // GET: api/Patients/5
        [HttpGet("{id}", Name = "Get_Patients")]
        public string Get(int id)
        {
            return "value";
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
