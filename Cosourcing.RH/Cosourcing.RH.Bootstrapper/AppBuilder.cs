using System;
using System.Reflection;
using Autofac;

namespace Cosourcing.RH.Bootstrapper
{
	public static class AppBuilder
	{
        public static void RegisterModules(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
        }
    }
}

