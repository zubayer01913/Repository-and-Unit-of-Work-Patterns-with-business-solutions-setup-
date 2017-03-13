using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using Test.Core.Model;
using Test.EntityFramework.DbContext;
using Test.Web.Models;
using Unity.Mvc5;
using Test.EntityFramework;

namespace Test.Web.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            var testDataAssembly = AppDomain.CurrentDomain.GetAssemblies()
                .First(a => a.FullName == "Test.EntityFramework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");

            var serviceAssembly = AppDomain.CurrentDomain.GetAssemblies()
               .First(a => a.FullName == "Test.Service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");

            container.RegisterType<ApplicationDbContext>(new PerResolveLifetimeManager());

            container.RegisterTypes(testDataAssembly.GetTypes(),
                WithMappings.FromMatchingInterface,
                WithName.Default);

            container.RegisterTypes(serviceAssembly.GetTypes(),
                WithMappings.FromMatchingInterface,
                WithName.Default);

            container.RegisterType<IUnitOfWork, UnitOfWork>();
           //UnitOfWork myInstance = container.Resolve<UnitOfWork>();

            container.RegisterType<IAuthenticationManager>(
                new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));

            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(
                new InjectionConstructor(typeof(ApplicationDbContext)));


            //container.RegisterType<IRoleStore<ApplicationRole, string>, RoleStore<ApplicationRole, string, IdentityUserRole>>(
            //    new InjectionConstructor(typeof(ApplicationDbContext)));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}