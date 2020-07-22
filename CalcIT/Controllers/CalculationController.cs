using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using CalcIt.Models;
using CalcIT.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalcIT.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin, Doctor")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        Calculation calculation;
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

    }
}
