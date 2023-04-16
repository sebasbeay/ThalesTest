using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ThalesTest.Models;

namespace ThalesTest.Business
{
    public interface IEmployeeBusiness
    {
        Employees GetEmployees();

        Employees GetEmployee(int id);
    }
}
