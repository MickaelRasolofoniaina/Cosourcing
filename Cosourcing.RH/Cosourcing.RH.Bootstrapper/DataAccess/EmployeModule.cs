using Autofac;
using Cosourcing.RH.Contracts.DataAccess.Employe;
using Cosourcing.RH.DataAccess.Employe;

namespace Cosourcing.RH.Bootstrapper.DataAccess
{
	public class EmployeModule : Module
	{
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<EmployeRepository>()
                .As<IEmployeRepository>()
                .SingleInstance();
        }
    }
}

