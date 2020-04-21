using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace CalcIt.Models
{
    public class DoctorModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Int64 doctor_id { get; set; }

        [StringLength(50)]
        public string name { get; set; }
        [StringLength(50)]
        public string surname { get; set; }
        [StringLength(50)]
        public string speciality { get; set; }

        public DateTime birthdate { get; set; }
        [StringLength(50)]
        public string login { get; set; }
        [StringLength(50)]
        public string password { get; set; }

      
    }
}
