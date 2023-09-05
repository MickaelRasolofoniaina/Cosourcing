using Autofac;
using Cosourcing.RH.Contracts.DataAccess;
using Cosourcing.RH.DataAccess;
using Cosourcing.RH.DataAccess.Context;
using Cosourcing.RH.Domain.Societe;
using Cosourcing.RH.Domain.User;
using Microsoft.EntityFrameworkCore;

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
                .Register<DbSet<UserModel>>(c =>
                {
                    var rhDbContext = c.Resolve<RHDbContext>();

                    return rhDbContext.User;
                })
                .AsSelf()
                .SingleInstance();

            containerBuilder
                .Register<DbSet<SocieteModel>>(c =>
                {
                    var rhDbContext = c.Resolve<RHDbContext>();

                    return rhDbContext.Societe;
                })
                .AsSelf()
                .SingleInstance();
        }
    }
}

