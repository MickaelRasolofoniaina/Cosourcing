using Autofac;
using Cosourcing.RH.Contracts.DataAccess.Inscription;
using Cosourcing.RH.DataAccess.Inscription;

namespace Cosourcing.RH.Bootstrapper.DataAccess
{
	public class InscriptionModule : Module
	{
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<InscriptionRepository>()
                .As<IInscriptionRepository>()
                .SingleInstance();
        }
    }
}

