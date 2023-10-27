using Autofac;
using Cosourcing.RH.Contracts.DataAccess.Affiliation;
using Cosourcing.RH.DataAccess.Affiliation;

namespace Cosourcing.RH.Bootstrapper.DataAccess
{
	public class AffiliationModule : Module
	{
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<AffiliationRepository>()
                .As<IAffiliationRepository>()
                .SingleInstance();
        }
    }
}

