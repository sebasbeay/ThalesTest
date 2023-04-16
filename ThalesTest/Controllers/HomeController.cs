using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThalesTest.Business;
using ThalesTest.DataAccess;
using ThalesTest.Models;

namespace ThalesTest.Controllers
{
    public class HomeController : Controller
    {
        public HomeController() { }

        private readonly IEmployeeBusiness _employee;
        private readonly ISalaryBusiness _salary;

        public HomeController(IEmployeeBusiness employee, ISalaryBusiness salary)
        {
            _employee = employee;
            _salary = salary;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult FilterEmployee(int? idEmployee)
        {
            Employees employees = new Employees();

            try
            {
                if (idEmployee != null)
                {
                    employees = _employee.GetEmployee(idEmployee.Value);
                }
                else
                {
                    employees = _employee.GetEmployees();
                }

                if (employees.status.ToUpper() == "SUCCESS")
                    employees = _salary.CalculateAnualSalary(employees);
            }
            catch (ArgumentException ex)
            {
                employees.status = "Error";
                employees.message = ex.Message;
            }

            return Json(employees, JsonRequestBehavior.AllowGet);
        }
    }
}