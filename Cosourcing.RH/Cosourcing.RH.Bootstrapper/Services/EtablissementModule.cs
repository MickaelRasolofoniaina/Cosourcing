using System;
using Autofac;
using Cosourcing.RH.Contracts.Services.Etablissement;
using Cosourcing.RH.Services.Etablissement;

namespace Cosourcing.RH.Bootstrapper.Services
{
    public class EtablissementModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<EtablissementService>()
                .As<IEtablissementService>()
                .SingleInstance();
        }
    }
}

