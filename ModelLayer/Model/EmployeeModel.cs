using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer.Model
{
    public class EmployeeModel
    {
        [Key]
        public int Emp_id { get; set; }
        public string Emp_name { get; set; }
        public string Profile_img { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Notes { get; set; }
    }
}
