using Autofac;
using Cosourcing.RH.Contracts.DataAccess;
using Cosourcing.RH.DataAccess;
using Cosourcing.RH.DataAccess.Context;

namespace Cosourcing.RH.Bootstrapper.DataAccess
{
	public class DbModule : Module
	{
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<RHDbContext>()
                .AsSelf()
                .SingleInstance();

            containerBuilder
                .RegisterType<BaseRepository>()
                .As<IBaseRepository>()
                .SingleInstance();

            containerBuilder
                .Register(c =>
                {
                    var rhDbContext = c.Resolve<RHDbContext>();

                    return rhDbContext.User;
                })
                .AsSelf()
                .SingleInstance();

            containerBuilder
                .Register(c =>
                {
                    var rhDbContext = c.Resolve<RHDbContext>();

                    return rhDbContext.Societe;
                })
                .AsSelf()
                .SingleInstance();

            containerBuilder
                .Register(c =>
                {
                    var rhDbContext = c.Resolve<RHDbContext>();

                    return rhDbContext.Etablissement;
                })
                .AsSelf()
                .SingleInstance();
            
            containerBuilder
                .Register(c =>
                {
                    var rhDbContext = c.Resolve<RHDbContext>();

                    return rhDbContext.Employe;
                })
                .AsSelf()
                .SingleInstance();
            containerBuilder
                .Register(c =>
                {
                    var rhDbContext = c.Resolve<RHDbContext>();

                    return rhDbContext.OrganismeSocial;
                })
                .AsSelf()
                .SingleInstance();
            
            containerBuilder
                .Register(c =>
                {
                    var rhDbContext = c.Resolve<RHDbContext>();

                    return rhDbContext.ServiceImpot;
                })
                .AsSelf()
                .SingleInstance();
            
            containerBuilder
                .Register(c =>
                {
                    var rhDbContext = c.Resolve<RHDbContext>();

                    return rhDbContext.Affiliation;
                })
                .AsSelf()
                .SingleInstance();

            containerBuilder
                .Register(c =>
                {
                    var rhDbContext = c.Resolve<RHDbContext>();

                    return rhDbContext.Inscription;
                })
                .AsSelf()
                .SingleInstance();


        }
    }
}

