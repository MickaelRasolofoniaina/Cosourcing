using Autofac;
using Cosourcing.RH.Contracts.Services.OrganismeSocial;
using Cosourcing.RH.Services.OrganismeSocial;

namespace Cosourcing.RH.Bootstrapper.Services
{
    public class OrganismeSocialModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<OrganismeSocialService>()
                .As<IOrganismeSocialService>()
                .SingleInstance();
        }
    }
}

