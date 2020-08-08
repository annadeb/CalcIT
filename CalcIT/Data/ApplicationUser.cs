using CalcIt.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalcIT.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Calculation> Calculations { get; set; }
        public ICollection<AuditTrail> AuditTrails { get; set; }
    }
}
