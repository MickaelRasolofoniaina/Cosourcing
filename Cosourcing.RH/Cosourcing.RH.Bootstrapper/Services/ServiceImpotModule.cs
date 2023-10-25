using Autofac;
using Cosourcing.RH.Contracts.Services.ServiceImpot;
using Cosourcing.RH.Services.ServiceImpot;

namespace Cosourcing.RH.Bootstrapper.Services
{
    public class ServiceImpotModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<ServiceImpotService>()
                .As<IServiceImpotService>()
                .SingleInstance();
        }
    }
}

