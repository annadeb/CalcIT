using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalcIt.Models
{
    public class AuditTrail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Int64 at_id { get; set; }
        [ForeignKey("doctor_id")]
        [Required]
        public Int64 doctor_id { get; set; }
        [Required]
        public DateTime date_time { get; set; }
        [Required]
        [StringLength(255)]
        public String events { get; set; }
    }
}
