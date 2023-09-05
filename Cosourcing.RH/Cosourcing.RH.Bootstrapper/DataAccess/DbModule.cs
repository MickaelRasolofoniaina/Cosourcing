using System;
using System.Collections.Generic;
using Autofac;
using Cosourcing.RH.Contracts.DataAccess;
using Cosourcing.RH.Contracts.DataAccess.User;
using Cosourcing.RH.Contracts.DataAccess.Etablissement;
using Cosourcing.RH.DataAccess;
using Cosourcing.RH.DataAccess.Context;
using Cosourcing.RH.DataAccess.User;
using Cosourcing.RH.DataAccess.Etablissement;
using Cosourcing.RH.Domain.User;
using Cosourcing.RH.Domain.Etablissement;
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
                .Register<DbSet<EtablissementModel>>(c =>
                {
                    var rhDbContext = c.Resolve<RHDbContext>();

                    return rhDbContext.Etablissement;
                })
                .AsSelf()
                .SingleInstance();

        }
    }
}

