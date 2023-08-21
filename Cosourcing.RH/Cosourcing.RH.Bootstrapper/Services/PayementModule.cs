using System;
using Autofac;
using Cosourcing.RH.Contracts.Services.Payement;
using Cosourcing.RH.Services.Payement;

namespace Cosourcing.RH.Bootstrapper.Services
{
    public class PayementModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<PayementService>()
                .As<IPayementService>()
                .SingleInstance();
        }
    }
}

