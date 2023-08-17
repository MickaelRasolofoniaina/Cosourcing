using System;
using Cosourcing.RH.Contracts.DataAccess.User;
using Cosourcing.RH.Domain.User;

namespace Cosourcing.RH.DataAccess.User
{
	public class UserRepository : IUserRepository
	{
		public UserRepository()
		{
		}

        public Task<UserModel> Save(UserModel user)
        {
            // Save to db 
            throw new NotImplementedException();
        }
    }
}

