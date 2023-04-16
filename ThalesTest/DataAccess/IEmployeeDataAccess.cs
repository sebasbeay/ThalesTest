using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ThalesTest.Models;

namespace ThalesTest.DataAccess
{
    public interface IEmployeeDataAccess
    {
        Employees GetAllEmployees();

        Employees GetEmployeeById(int? idEmployee);        
    }
}
