using CalcIT.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalcIt.Models
{
    public class Calculation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int64 calculation_id { get; set; }
        [ForeignKey("patient_id")]
        [Required]
        public Int64 patient_id { get; set; }
        public DateTime calculation_date { get; set; }
        [StringLength(255)]
        public string calculation_data { get; set; }
        [StringLength(50)]
        public string calculation_type { get; set; }
        [StringLength(255)]
        public string result { get; set; }
        public virtual Patient Patient { get; set; }
        
        [Required]
        public string user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
