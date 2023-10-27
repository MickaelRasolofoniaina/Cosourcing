using Autofac;
using Cosourcing.RH.Contracts.Services.Inscription;
using Cosourcing.RH.Services.Inscription;

namespace Cosourcing.RH.Bootstrapper.Services
{
    public class InscriptionModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<InscriptionService>()
                .As<IInscriptionService>()
                .SingleInstance();
        }
    }
}

