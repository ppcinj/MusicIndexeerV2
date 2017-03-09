using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace MusicIndexeerV2.Autofac
{
    public static class AutofacScope
    {
        private static ILifetimeScope _scope;

        public static ILifetimeScope Scope => _scope ?? (_scope = GetLifetimeScope());

        private static ILifetimeScope GetLifetimeScope()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(a => a.Name.StartsWith("Form"));

            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(a => a.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(a => a.Name.EndsWith("Facade"))
                .AsImplementedInterfaces();

            return containerBuilder.Build().BeginLifetimeScope();
        }
    }
}
