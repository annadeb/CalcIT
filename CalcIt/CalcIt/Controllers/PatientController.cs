using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalcIt.Controllers
{
    public class PatientController : Controller
    {
        // GET: /<controller>/
        //https://localhost:44308/Patient/ => to jest to niżej
        public IActionResult Index()
        {
            //return "This is my default action...";
            ViewData["Patient"] = "Jan Kowalski"; // przekazywanie danych 

            return View();
        }


        // GET: /HelloWorld/Welcome/ 
        //%https://localhost:44308/Patient/Welcome => a to jest to niżej  
        //public string Welcome(string name, int ID=1)
        //{
        //    //return "This is the Welcome action method...";
        //    //  return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        //   return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
           
        //}
    }
    }

