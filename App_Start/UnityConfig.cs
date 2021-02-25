using ITRoot_Task.Repositres;
using ITRoot_Task.Repositres.IRepositries;
using ITRoot_Task.Services;
using ITRoot_Task.Services.IServices;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ITRoot_Task
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IInvoiceService,InvoiceService>();
            container.RegisterType<IUserRepositry, UserRepositry>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IInvoiceRepositry, InvoiceRepositry>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}