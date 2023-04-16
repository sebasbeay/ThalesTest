using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using ThalesTest.Controllers;
using ThalesTest.Business;
using ThalesTest.DataAccess;

namespace ThalesTest
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IEmployeeBusiness, EmployeeBusiness>();
            container.RegisterType<ISalaryBusiness, SalaryBusiness>();
            container.RegisterType<IEmployeeDataAccess, EmployeesDataAccess>();

            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }
}