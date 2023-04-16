using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using ThalesTest.Models;

namespace ThalesTest.DataAccess
{
    public class EmployeesDataAccess : IEmployeeDataAccess
    {
        public Employees GetAllEmployees()
        {
            Employees employees = new Employees();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://dummy.restapiexample.com/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("v1/employees").Result;

                if (response.StatusCode == (System.Net.HttpStatusCode)429)
                    throw new HttpRequestException("The server is too busy now, please try again later.");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    employees = JsonConvert.DeserializeObject<Employees>(jsonResult);
                }
            }

            return employees;
        }

        public Employees GetEmployeeById(int? idEmployee)
        {
            Employees employees = new Employees();

            if (idEmployee == null)
                throw new ArgumentNullException("The Employee Id must be necessary");

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://dummy.restapiexample.com/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                StringBuilder requestUri = new StringBuilder();
                requestUri.Append("v1/employee/");
                requestUri.Append(idEmployee.ToString());
                HttpResponseMessage response = client.GetAsync(requestUri.ToString()).Result;

                if (response.StatusCode == (System.Net.HttpStatusCode)429)
                    throw new HttpRequestException("The server is too busy now, please try again later.");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    Employee employee = JsonConvert.DeserializeObject<Employee>(jsonResult);
                    employees.status = employee.status;
                    employees.message = employee.message;
                    employees.data = new List<EmployeeData>() { employee.data };
                }
            }

            return employees;
        }
    }
}