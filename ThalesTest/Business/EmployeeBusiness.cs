using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using ThalesTest.DataAccess;
using ThalesTest.Models;

namespace ThalesTest.Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeDataAccess _employeeDataAccess;
        public EmployeeBusiness(IEmployeeDataAccess employee)
        {
            _employeeDataAccess = employee;
        }

        public Employees GetEmployees()
        {
            Employees employee = new Employees();
            try
            {
                employee = _employeeDataAccess.GetAllEmployees();
            }
            catch (HttpRequestException ex)
            {
                employee.status = "error";
                employee.message = ex.Message;
            }

            return employee;
        }

        public Employees GetEmployee(int id)
        {
            Employees employee = new Employees();
            try
            {
                employee = _employeeDataAccess.GetEmployeeById(id);
            }
            catch (ArgumentNullException ex)
            {
                employee.status = "error";
                employee.message = ex.Message;
            }
            catch (HttpRequestException ex)
            {
                employee.status = "error";
                employee.message = ex.Message;
            }

            return employee;
        }
    }
}