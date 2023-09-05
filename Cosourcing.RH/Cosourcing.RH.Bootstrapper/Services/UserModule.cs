using Autofac;
using Cosourcing.RH.Contracts.Services.User;
using Cosourcing.RH.Services.User;

namespace Cosourcing.RH.Bootstrapper.Services
{
    public class UserModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<UserService>()
                .As<IUserService>()
                .SingleInstance();
        }
    }
}

