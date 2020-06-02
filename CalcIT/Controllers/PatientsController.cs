﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalcIt.Models;
using CalcIT.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CalcIT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        // GET: api/Patients
        private readonly UserContext _context;
        public PatientsController(UserContext context)
        {
            _context = context;
        }
        //[HttpGet]
        //public IEnumerable<Patient> Get()
        //{
        //    //var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
        //    //optionsBuilder.UseSqlServer("Data Source=CalcIt.db");


        //    using (_context)
        //    {
        //        var pat = new List<Patient>()
        //        {
        //         new Patient {name = "Janek", surname="Kowalski", PESEL=97072058336, department_id=1, birthdate=DateTime.Parse("20.07.1997"), height=178, registration_date=DateTime.Now.AddDays(-1), weight=78.5},
        //         new Patient {name = "Klaudia", surname="Rózia", PESEL=98042158354, department_id=3, birthdate=DateTime.Parse("21.04.1998"), height=180, registration_date=DateTime.Now.AddDays(-5), weight=68.5},
        //         new Patient {name = "Joanna", surname="Czujek", PESEL=92042058386, department_id=2, birthdate=DateTime.Parse("20.04.1992"), height=161, registration_date=DateTime.Now.AddDays(-10), weight=55},
        //         new Patient {name = "Marian", surname="Zuber", PESEL=95052058323, department_id=2, birthdate=DateTime.Parse("20.05.1995"), height=175, registration_date=DateTime.Now.AddDays(-3), weight=73.5},
        //         new Patient {name = "Michał", surname="Cose", PESEL=91052758335, department_id=1, birthdate=DateTime.Parse("27.05.1991"), height=185, registration_date=DateTime.Now.AddDays(-2), weight=83.5},
        //         new Patient {name = "Michał", surname="Barłoś", PESEL=96102058336, department_id=3, birthdate=DateTime.Parse("20.10.1996"), height=182, registration_date=DateTime.Now.AddDays(-7), weight=94},
        //         new Patient {name = "Halina", surname="Jeżyna", PESEL=95051058336, department_id=1, birthdate=DateTime.Parse("10.05.1995"), height=165, registration_date=DateTime.Now, weight=52.1},
        //         new Patient {name = "Marcin", surname="Wariacin", PESEL=85052058336, department_id=1, birthdate=DateTime.Parse("20.05.1985"), height=195, registration_date=DateTime.Now.AddDays(1), weight=97.5},
        //         new Patient {name = "Ola", surname="Dziubol", PESEL=99051858231, department_id=2, birthdate=DateTime.Parse("18.05.1999"), height=154, registration_date=DateTime.Now.AddDays(1), weight=49.5},
        //         new Patient {name = "Kot", surname="Miałczyn Drappke", PESEL=53050158336, department_id=3, birthdate=DateTime.Parse("01.05.1953"), height=180, registration_date=DateTime.Now.AddDays(-3), weight=73.5},
        //         new Patient {name = "Oliwia", surname="Sprawiedliwia", PESEL=64050118336, department_id=3, birthdate=DateTime.Parse("11.05.1964"), height=158, registration_date=DateTime.Now.AddDays(1), weight=58},
        //         new Patient {name = "Kamil", surname="Marcinkiewicz", PESEL=94050708336, department_id=2, birthdate=DateTime.Parse("07.05.1994"), height=184, registration_date=DateTime.Now.AddDays(-2), weight=85}
        //        };
        //        _context.Patients.AddRange(pat);
        //        _context.SaveChanges();

        //        //    _context.Patients.Add(pat);
        //        //    _context.SaveChanges();
        //        //}
        //        return;
        //    };
        //}
        // GET: api/Patients/5
        [HttpGet("{id}")]
        public IEnumerable<Patient> GetPatients(int id)
        {
            using (_context)
            {
                //var pat = new List<Patient>()
                //{
                // new Patient {name = "Janek", surname="Kowalski", PESEL=97072058336, department_id=1, birthdate=DateTime.Parse("20.07.1997"), height=178, registration_date=DateTime.Now.AddDays(-1), weight=78.5},
                // new Patient {name = "Klaudia", surname="Rózia", PESEL=98042158354, department_id=3, birthdate=DateTime.Parse("21.04.1998"), height=180, registration_date=DateTime.Now.AddDays(-5), weight=68.5},
                // new Patient {name = "Joanna", surname="Czujek", PESEL=92042058386, department_id=2, birthdate=DateTime.Parse("20.04.1992"), height=161, registration_date=DateTime.Now.AddDays(-10), weight=55},
                // new Patient {name = "Marian", surname="Zuber", PESEL=95052058323, department_id=2, birthdate=DateTime.Parse("20.05.1995"), height=175, registration_date=DateTime.Now.AddDays(-3), weight=73.5},
                // new Patient {name = "Michał", surname="Cose", PESEL=91052758335, department_id=1, birthdate=DateTime.Parse("27.05.1991"), height=185, registration_date=DateTime.Now.AddDays(-2), weight=83.5},
                // new Patient {name = "Michał", surname="Barłoś", PESEL=96102058336, department_id=3, birthdate=DateTime.Parse("20.10.1996"), height=182, registration_date=DateTime.Now.AddDays(-7), weight=94},
                // new Patient {name = "Halina", surname="Jeżyna", PESEL=95051058336, department_id=1, birthdate=DateTime.Parse("10.05.1995"), height=165, registration_date=DateTime.Now, weight=52.1},
                // new Patient {name = "Marcin", surname="Wariacin", PESEL=85052058336, department_id=1, birthdate=DateTime.Parse("20.05.1985"), height=195, registration_date=DateTime.Now.AddDays(1), weight=97.5},
                // new Patient {name = "Ola", surname="Dziubol", PESEL=99051858231, department_id=2, birthdate=DateTime.Parse("18.05.1999"), height=154, registration_date=DateTime.Now.AddDays(1), weight=49.5},
                // new Patient {name = "Kot", surname="Miałczyn Drappke", PESEL=53050158336, department_id=3, birthdate=DateTime.Parse("01.05.1953"), height=180, registration_date=DateTime.Now.AddDays(-3), weight=73.5},
                // new Patient {name = "Oliwia", surname="Sprawiedliwia", PESEL=64050118336, department_id=3, birthdate=DateTime.Parse("11.05.1964"), height=158, registration_date=DateTime.Now.AddDays(1), weight=58},
                // new Patient {name = "Kamil", surname="Marcinkiewicz", PESEL=94050708336, department_id=2, birthdate=DateTime.Parse("07.05.1994"), height=184, registration_date=DateTime.Now.AddDays(-2), weight=85}
                //};
                //_context.Patients.AddRange(pat);
                //_context.SaveChanges();



                var patients = _context.Patients.Where(x => x.department_id == id).ToList();

                return patients;
            };
            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> Get_PatientInfo(int id)
        {
            var patient = await _context.Patients
             .FirstOrDefaultAsync(m => m.patient_id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }
        [HttpGet("{id}")]
        public IEnumerable<Calculation> Get_PatientResults(int id)
        {
            //var calc = new List<Calculation>()
            //{
            // new Calculation {calculation_date=DateTime.Parse("2019-08-07"),calculation_type="BMI",calculation_data="weight=56;height=1.66",patient_id=1,doctor_id=1,result="BMI=21.6" },
            // new Calculation {calculation_date=DateTime.Today,calculation_type="BMI",calculation_data="weight=46;height=1.66",patient_id=1,doctor_id=1,result="18.6" },
            // new Calculation {calculation_date=DateTime.Today,calculation_type="Kalkulator ciąży",calculation_data="date=20-05-2020;lenght=28",patient_id=1,doctor_id=1,result="date=02-02-2021" }
            //};
            //_context.Calculations.AddRange(calc);
            //_context.SaveChanges();


            var result = _context.Calculations.Where(x => x.patient_id == id).ToList();
            return result;
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