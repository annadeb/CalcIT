using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CalcIt.Models;

namespace CalcIt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpGet]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Email == "login@ip.pl" && user.Password == "haselko")
                {
                    return RedirectToAction("DepartmentView");
                }


            }
            return View();
        }
        public IActionResult DepartmentView(Department department)
        {
            var departments = new Department[3];
            departments[0] = new Department { DepartmentID = 1, Name = "Chirurgia" };
            departments[1] = new Department { DepartmentID = 2, Name = "Zakaźny" };
            departments[2] = new Department { DepartmentID = 3, Name = "Pulmonologia" };
            return View(departments);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
