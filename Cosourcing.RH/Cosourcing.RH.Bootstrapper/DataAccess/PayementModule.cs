using System;
using Autofac;
using Cosourcing.RH.Contracts.DataAccess.Payement;
using Cosourcing.RH.DataAccess.Payement;

namespace Cosourcing.RH.Bootstrapper.DataAccess
{
	public class PayementModule : Module
	{
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<PayementRepository>()
                .As<IPayementRepository>()
                .SingleInstance();
        }
    }
}

