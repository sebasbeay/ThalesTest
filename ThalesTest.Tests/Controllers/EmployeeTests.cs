using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThalesTest.DataAccess;

namespace ThalesTest.Tests.Controllers
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void AllEmployeesTest()
        {
            EmployeesDataAccess classDataAccess = new EmployeesDataAccess();

            var result = classDataAccess.GetAllEmployees();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EmployeeByIdTest()
        {
            EmployeesDataAccess classDataAccess = new EmployeesDataAccess();

            var result = classDataAccess.GetEmployeeById(1);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void WrongEmployeeByIdTest()
        {
            EmployeesDataAccess classDataAccess = new EmployeesDataAccess();

            var result = classDataAccess.GetEmployeeById(100);

            Assert.IsNull(result.data.FirstOrDefault());
        }
    }
}
