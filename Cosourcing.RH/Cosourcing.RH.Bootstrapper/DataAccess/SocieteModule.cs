
using System;
using Autofac;
using Cosourcing.RH.Contracts.DataAccess.Societe;
using Cosourcing.RH.DataAccess.Societe;

namespace Cosourcing.RH.Bootstrapper.DataAccess
{
    public class SocieteModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<SocieteRepository>()
                .As<ISocieteRepository>()
                .SingleInstance();
        }
    }
}
