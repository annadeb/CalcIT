using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalcIt.Models
{
    public class DepartmentModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Int64 department_id { get; set; }
        [StringLength(50)]
        public string name { get; set; }
    }
}
