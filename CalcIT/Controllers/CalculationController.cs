using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalcIt.Models;
using CalcIT.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalcIT.Controllers
{
    [Route("api/[controller]/[action]")]
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

    }
}
