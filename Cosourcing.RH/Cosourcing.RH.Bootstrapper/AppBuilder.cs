using System;
using System.Reflection;
using System.Text;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Cosourcing.RH.Services.Auth;

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
