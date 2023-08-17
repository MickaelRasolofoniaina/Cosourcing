using System;
using Cosourcing.RH.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cosourcing.RH.Bootstrapper
{
	public static class AppConfiguration
	{
        public static void ConfigureServices(this IServiceCollection service, string dbConnectionString)
        {
            service.AddDbContext<RHDbContext>(options =>
            {
                options.UseNpgsql(dbConnectionString);
            });
        }
    }
}

