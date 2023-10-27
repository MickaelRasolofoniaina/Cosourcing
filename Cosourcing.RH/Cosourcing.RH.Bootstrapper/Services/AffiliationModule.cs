using Autofac;
using Cosourcing.RH.Contracts.Services.Affiliation;
using Cosourcing.RH.Services.Affiliation;

namespace Cosourcing.RH.Bootstrapper.Services
{
    public class AffiliationModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<AffiliationService>()
                .As<IAffiliationService>()
                .SingleInstance();
        }
    }
}

