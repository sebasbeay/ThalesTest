using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThalesTest.Models;

namespace ThalesTest.Business
{
    public class SalaryBusiness : ISalaryBusiness
    {
        private int AnualSalary(int? monthSalary)
        {
            if (monthSalary == null)
                throw new ArgumentNullException("You must send the employee's monthly salary");

            return monthSalary.Value * 12;
        }

        public Employees CalculateAnualSalary(Employees employees)
        {
            if (employees == null)
                throw new ArgumentNullException("You must send at least one employee");

            if (employees.data == null)
                throw new ArgumentException("That employee doesn't exist in our database");

            foreach (EmployeeData employee in employees.data)
            {
                if (employee == null)
                    throw new ArgumentException("That employee doesn't exist in our database");

                employee.employee_anual_salary = AnualSalary(employee.employee_salary);
            }

            return employees;
        }
    }
}