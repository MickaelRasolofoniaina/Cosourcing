using System;
using Cosourcing.RH.Contracts.DataAccess.User;
using Cosourcing.RH.Contracts.Services.User;
using Cosourcing.RH.Domain.User;

namespace Cosourcing.RH.Services.User
{
	public class UserService : IUserService
	{
		private IUserRepository _userRepository;

		public UserService(
			IUserRepository userRepository
		)
		{
			_userRepository = userRepository;
		}

        public Task<UserModel> Save(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}

