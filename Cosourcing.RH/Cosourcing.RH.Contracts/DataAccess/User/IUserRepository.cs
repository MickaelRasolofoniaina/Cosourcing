using System;
using Cosourcing.RH.Domain.User;

namespace Cosourcing.RH.Contracts.DataAccess.User
{
	public interface IUserRepository
	{
		public Task<UserModel[]> GetAllUsers();
    }
}

