using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalcIt.Models;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace CalcIt.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<DoctorModel> Doctors { get; set; }
        public DbSet<DepartmentModel> Departmens { get; set; }
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<CalculationModel> Calculations { get; set; }
        public DbSet<AuditTrailModel> AuditTrails { get; set; }
    }
    //EntityFrameworkCore\Add-migration AuditTrail
}
