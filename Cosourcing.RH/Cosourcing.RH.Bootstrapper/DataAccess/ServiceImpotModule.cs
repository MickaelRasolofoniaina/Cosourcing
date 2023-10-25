using Autofac;
using Cosourcing.RH.Contracts.DataAccess.ServiceImpot;
using Cosourcing.RH.DataAccess.ServiceImpot;

namespace Cosourcing.RH.Bootstrapper.DataAccess
{
	public class ServiceImpotModule : Module
	{
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<ServiceImpotRepository>()
                .As<IServiceImpotRepository>()
                .SingleInstance();
        }
    }
}

