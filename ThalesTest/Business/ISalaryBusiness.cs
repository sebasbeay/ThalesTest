using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThalesTest.Models;

namespace ThalesTest.Business
{
    public interface ISalaryBusiness
    {
        Employees CalculateAnualSalary(Employees employees);
    }
}
