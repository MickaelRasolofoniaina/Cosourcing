using System;
using Cosourcing.RH.Domain.User;

namespace Cosourcing.RH.Contracts.Services.User
{
	public interface IUserService
	{
		public Task<int> Save(UserModel user);

        public Task<int> UpdateEmail(int id, string email);

        public ValueTask<UserModel?> GetById(int id);

        public Task<UserModel[]> GetAll();

        public Task<int> DeleteUser(int id);
    }
}

