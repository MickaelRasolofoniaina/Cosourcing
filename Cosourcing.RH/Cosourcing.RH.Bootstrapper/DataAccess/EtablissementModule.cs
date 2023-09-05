using System;
using Autofac;
using Cosourcing.RH.Contracts.DataAccess.Etablissement;
using Cosourcing.RH.DataAccess.Etablissement;

namespace Cosourcing.RH.Bootstrapper.DataAccess
{
	public class EtablissementModule : Module
	{
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<EtablissementRepository>()
                .As<IEtablissementRepository>()
                .SingleInstance();
        }
    }
}

