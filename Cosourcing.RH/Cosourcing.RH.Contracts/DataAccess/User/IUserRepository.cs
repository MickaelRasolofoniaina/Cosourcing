using System;
using Cosourcing.RH.Domain.User;

namespace Cosourcing.RH.Contracts.DataAccess.User
{
	public interface IUserRepository
	{
		public void Add(UserModel user);
	}
}

