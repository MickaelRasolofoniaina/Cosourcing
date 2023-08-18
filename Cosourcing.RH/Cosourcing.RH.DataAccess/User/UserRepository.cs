using System;
using Cosourcing.RH.Contracts.DataAccess.User;
using Cosourcing.RH.DataAccess.Context;
using Cosourcing.RH.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Cosourcing.RH.DataAccess.User
{
	public class UserRepository : IUserRepository
	{
        private DbSet<UserModel> _userDbContext;

		public UserRepository(DbSet<UserModel> userDbContext)
		{
            _userDbContext = userDbContext;
        }

        public Task<UserModel[]> GetAllUsers()
        {
            return _userDbContext.ToArrayAsync();
        }
    }
}

