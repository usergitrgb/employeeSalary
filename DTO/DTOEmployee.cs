using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOEmployee: clsEmployee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string contractTypeName { get; set; }
        public int roleId { get; set; }
        public string roleName { get; set; }
        public object roleDescription { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double hourlySalary { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double monthlySalary { get; set; }
    }
}
