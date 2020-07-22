using CalcIt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalcIT.Data
{
    public class UserContext : IdentityDbContext<ApplicationUser, IdentityRole,string>
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        //public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departmens { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Calculation> Calculations { get; set; }
        public DbSet<AuditTrail> AuditTrails { get; set; }

    }
}
