using System;
using Autofac;
using Cosourcing.RH.Contracts.DataAccess.User;
using Cosourcing.RH.DataAccess.User;

namespace Cosourcing.RH.Bootstrapper.DataAccess
{
	public class UserModule : Module
	{
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<UserRepository>()
                .As<IUserRepository>()
                .SingleInstance();
        }
    }
}

