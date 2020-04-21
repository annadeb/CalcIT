using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalcIt.Models
{
    public class PatientModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Int64 patient_id { get; set; }
        [ForeignKey("doctor_id")]
        [Required]
        public Int64 doctor_id { get; set; }
        [Required]
        public Int64 PESEL { get; set; }
        [StringLength(50)]
        public string name { get; set; }
        [StringLength(50)]
        public string surname { get; set; }
        [StringLength(50)]
        public double weight { get; set; }
        public double height { get; set; }

        public DateTime registration_date { get; set; }
        public DateTime birthdate { get; set; }
    }
}
