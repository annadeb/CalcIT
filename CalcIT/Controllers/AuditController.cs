using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalcIt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Web;
using IdentityServer4.Extensions;
using CalcIT.Data;
using Microsoft.EntityFrameworkCore;

namespace CalcIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly UserContext _context;
        public AuditController(UserContext context)
        {
            _context = context;
        }
        public class AuditAttribute : ActionFilterAttribute
        {

            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var connectionstring = "Data Source = (localdb)\\MSSQLLocalDB; Database = CalcIt; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

                var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
                optionsBuilder.UseSqlServer(connectionstring);

                // Stores the Audit in the Database  
                UserContext context = new UserContext(optionsBuilder.Options);

                var request = filterContext.HttpContext.Request;
                var user = filterContext.HttpContext.User.IsAuthenticated() ? filterContext.HttpContext.User.Claims.FirstOrDefault().Value : "Anonymous";
                AuditTrail audit = new AuditTrail()
                {
                    user_id = user,
                    events = request.Path,
                    status_code = request.HttpContext.Response.StatusCode,
                    date_time = DateTime.UtcNow,
                    ApplicationUser = context.Users.FirstOrDefault(x => x.UserName == user)

                };


                context.AuditTrails.Add(audit);
                context.SaveChanges();



                // Finishes executing the Action as normal   
                base.OnActionExecuting(filterContext);
            }
        }
    }
}