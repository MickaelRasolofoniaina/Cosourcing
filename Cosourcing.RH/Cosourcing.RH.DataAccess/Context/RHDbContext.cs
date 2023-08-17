using System;
using Cosourcing.RH.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Cosourcing.RH.DataAccess.Context
{
	public class RHDbContext : DbContext
	{
		public RHDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<UserModel> User { get; set; }
    }
}

