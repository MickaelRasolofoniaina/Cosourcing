using System;
using Cosourcing.RH.Domain.User;
using Microsoft.EntityFrameworkCore;
using Cosourcing.RH.Domain.Etablissement;

namespace Cosourcing.RH.DataAccess.Context
{
	public class RHDbContext : DbContext
	{
		public RHDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<UserModel> User { get; set; }
		public DbSet<EtablissementModel> Etablissement { get; set; }
    }
}

