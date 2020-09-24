using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
//using System.Web.Http.ModelBinding;
using CalcIt.Models;
using CalcIT.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static CalcIT.Controllers.AuditController;


namespace CalcIT.Controllers
{
    [Route("api/[controller]/[action]")]
    [Audit]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin,Doctor")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly UserContext _context;
        public PatientsController(UserContext context)
        {
            _context = context;
        }
        [Audit]
        [HttpGet("{id}")]
        public IEnumerable<Patient> GetPatients(int id)
        {
            using (_context)
            {
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
            var result = _context.Calculations.Where(x => x.patient_id == id).ToList();
            return result;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] Patient model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                using (_context)
                {
                    _context.Patients.Add(new Patient()
                    {
                        name = model.name,
                        surname = model.surname,
                        birthdate = model.birthdate,
                        PESEL = model.PESEL,
                        height = model.height,
                        weight = model.weight,
                        department_id = model.department_id,
                        registration_date = DateTime.Now,
                    });

                    await _context.SaveChangesAsync();
                };
                return Ok("Patient's been added");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            //do wyboru ta akcja (na wzor kalkulacji) lub create patient
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Patient), new { id = patient.patient_id }, patient);
        }
        [HttpGet]
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var departments = await _context.Departmens.ToListAsync();
            return departments;
        }
        [HttpPost("{patientId}")]
        public async Task<IActionResult> UpdatePatient([FromBody] Patient model, long patientId)
        {
            var patient = _context.Patients.FirstOrDefault(x => x.patient_id == patientId);
            if (patient == null)
            {
                return NotFound("Such patient doesn't exist.");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }
                else
                {
                    patient.name = model.name;
                    patient.surname = model.surname;
                    patient.birthdate = model.birthdate;
                    patient.PESEL = model.PESEL;
                    patient.height = model.height;
                    patient.weight = model.weight;
                    patient.department_id = model.department_id;
                    patient.registration_date = DateTime.Now;
                    _context.Patients.Update(patient);
                };

                await _context.SaveChangesAsync();

                return Ok("Patient's been updated");

            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{patientId}")]
        public async Task<IActionResult> DeletePatient(long patientId)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.patient_id == patientId);
            if (patient == null)
            {
                return NotFound("Such patient doesn't exist.");
            }
            else
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
                return Ok("Patient's been removed");
            }

        }
    }
}
