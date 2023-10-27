﻿using Cosourcing.RH.Domain.User;
using Microsoft.EntityFrameworkCore;
using Cosourcing.RH.Domain.Entite;

namespace Cosourcing.RH.DataAccess.Context
{
	public class RHDbContext : DbContext
	{
		public RHDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<UserModel> User { get; set; }
		public DbSet<InscriptionModel> Inscription { get; set; }
		public DbSet<AffiliationModel> Affiliation { get; set; }
		public DbSet<ServiceImpotModel> ServiceImpot { get; set; }
		public DbSet<OrganismeSocialModel> OrganismeSocial { get; set; }
		public DbSet<EmployeModel> Employe { get; set; }
		public DbSet<EtablissementModel> Etablissement { get; set; }
		public DbSet<SocieteModel> Societe { get; set; }
		
    }
}

