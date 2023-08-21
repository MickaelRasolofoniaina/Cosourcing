using System;
using Cosourcing.RH.Domain.User;
using Microsoft.EntityFrameworkCore;
using Cosourcing.RH.Domain.Payement;

namespace Cosourcing.RH.DataAccess.Context
{
	public class RHDbContext : DbContext
	{
		public RHDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<UserModel> User { get; set; }
		public DbSet<PayementModel> Payement { get; set; }
    }
}

