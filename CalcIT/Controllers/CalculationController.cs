using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
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
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using static CalcIT.Controllers.AuditController;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalcIT.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin, Doctor")]
    [Route("api/[controller]/[action]")]
    [Audit]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly UserContext _context;
        public CalculationController(UserContext context)
        {
            _context = context;
        }



        [HttpPost]
        public async Task<ActionResult<Calculation>> PostCalculation(Calculation calculation)
        {
            _context.Calculations.Add(calculation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Calculation), new { id = calculation.calculation_id }, calculation);
        }
        //[HttpPost]
        //public async Task <IActionResult> CreateCalculation([FromBody] Calculation model)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Not a valid model");
        //    }
        //    else
        //    {
        //        using (_context)
        //        {
        //            _context.Calculations.Add(new Calculation()
        //            {
        //              calculation_type=model.calculation_type,
        //              calculation_date=DateTime.Now,
        //              patient_id=model.patient_id,
        //              user_id = User.FindFirst(ClaimTypes.NameIdentifier).Value,
        //              result = model.result,
        //              calculation_data=model.calculation_data
        //        });

        //            await _context.SaveChangesAsync();
        //        };
        //        return Ok();
        //    }
        //}
    }
}
