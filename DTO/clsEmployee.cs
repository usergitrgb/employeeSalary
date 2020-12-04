using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsEmployee
    {
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double annualSalary { get; set; }
    }
}
