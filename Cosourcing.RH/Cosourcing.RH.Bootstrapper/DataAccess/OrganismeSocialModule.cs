using Autofac;
using Cosourcing.RH.Contracts.DataAccess.OrganismeSocial;
using Cosourcing.RH.DataAccess.OrganismeSocial;

namespace Cosourcing.RH.Bootstrapper.DataAccess
{
	public class OrganismeSocialModule : Module
	{
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<OrganismeSocialRepository>()
                .As<IOrganismeSocialRepository>()
                .SingleInstance();
        }
    }
}

