using Autofac;
using Cosourcing.RH.Contracts.Services.Employe;
using Cosourcing.RH.Services.Employe;

namespace Cosourcing.RH.Bootstrapper.Services
{
    public class EmployeModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<EmployeService>()
                .As<IEmployeService>()
                .SingleInstance();
        }
    }
}

