using System.Web.Mvc;
using Konzole.InventorySystem.Providers;
using Konzole.InventorySystem.Providers.Interface;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace Konzole.InventorySystem.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICustomerProvider, CustomerProvider>();
            container.RegisterType<ILoggingProvider, LoggingProvider>();
            container.RegisterType<IPersonProvider, PersonProvider>();
            container.RegisterType<ISupllierProvider, SupplierProvider>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}