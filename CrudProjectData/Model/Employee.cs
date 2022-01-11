using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudProjectData.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        [Display(Name = "Employee Number")]
        public string Emp_no { get; set; }

        [Display(Name = "Branch Name")]
        public string Branch { get; set; }

        [Display(Name = "Department Name")]
        public string Department { get; set; }

    }
}
