using System;
using Autofac;
using Cosourcing.RH.Contracts.Services.Societe;
using Cosourcing.RH.Services.Societe;

namespace Cosourcing.RH.Bootstrapper.Services
{
    public class SocieteModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<SocieteService>()
                .As<ISocieteService>()
                .SingleInstance();
        }
    }
}

