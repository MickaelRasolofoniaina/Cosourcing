using Cosourcing.RH.Domain.User;
using Microsoft.EntityFrameworkCore;
using Cosourcing.RH.Domain.Etablissement;
using Cosourcing.RH.Domain.Societe;

namespace Cosourcing.RH.DataAccess.Context
{
	public class RHDbContext : DbContext
	{
		public RHDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<UserModel> User { get; set; }
		public DbSet<EtablissementModel> Etablissement { get; set; }
		public DbSet<SocieteModel> Societe { get; set; }
    }
}

