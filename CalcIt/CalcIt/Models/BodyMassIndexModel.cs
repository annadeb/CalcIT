using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalcIt.Models
{
    public class BodyMassIndexModel
    {

        //[Required]
        [Range(1, 1000, ErrorMessage = "Waga poza zakresem (1-1000).")]
        public double Weight { get; set; }

        //[Required]
        [Range(1, 1000, ErrorMessage = "Wzrost poza zakresem (1-4).")]
        public double Height { get; set; }

        public double BMI { get; set; }
    }
}
