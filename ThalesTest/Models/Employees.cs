using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThalesTest.Models
{
    public class Employees : EmployeeBase
    {
        public List<EmployeeData> data { get; set; }
    }

    public class Employee : EmployeeBase
    {
        public EmployeeData data { get; set; }
    }

    public class EmployeeData
    {
        public int id { get; set; }

        public string employee_name { get; set; }

        public int employee_salary { get; set; }

        public int employee_age { get; set; }

        public string profile_image { get; set; }

        public int employee_anual_salary { get; set; }
    }
}