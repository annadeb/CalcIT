using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalcIt.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalcIt.Controllers
{
    public class BodyMassIndexController : Controller
    {
        BodyMassIndexModel bmi;
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateBMI(string weight, string height)
        {
            bmi = new BodyMassIndexModel();
            weight = weight.Replace(".",",");
            height = height.Replace(".", ",");
            bmi.Weight = double.Parse(weight);
            bmi.Height = double.Parse(height);
            bmi.BMI = bmi.Weight / (bmi.Height * bmi.Height);
            ViewData["BMI"] = bmi.BMI; 
            //LogModel Log1 =  
            return View("Index");
        }
    }
}
