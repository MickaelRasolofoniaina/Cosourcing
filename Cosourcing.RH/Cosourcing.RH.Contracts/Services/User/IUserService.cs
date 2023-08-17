using System;
using Cosourcing.RH.Domain.User;

namespace Cosourcing.RH.Contracts.Services.User
{
	public interface IUserService
	{
		public Task<int> Save(UserModel user);
	}
}

