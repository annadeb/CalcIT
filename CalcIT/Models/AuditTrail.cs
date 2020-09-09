using CalcIT.Data;
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int64 at_id { get; set; }
        [Required]
        public DateTime date_time { get; set; }
        [Required]
        [StringLength(255)]
        public String events { get; set; }
        public int status_code { get; set; }
        [Required]
        public string user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
