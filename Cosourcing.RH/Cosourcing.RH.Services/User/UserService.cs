using System;
using Cosourcing.RH.Contracts.DataAccess;
using Cosourcing.RH.Contracts.DataAccess.User;
using Cosourcing.RH.Contracts.Services.User;
using Cosourcing.RH.Domain.User;

namespace Cosourcing.RH.Services.User
{
	public class UserService : IUserService
	{
		private IBaseRepository _baseRepository;
		private IUserRepository _userRepository;

		public UserService(
			IBaseRepository baseRepository,
			IUserRepository userRepository
		)
		{
			_baseRepository = baseRepository;
			_userRepository = userRepository;
		}

        public async Task<int> Save(UserModel user)
        {
            _baseRepository.Add<UserModel>(user);

			return await _baseRepository.Commit();
        }
    }
}

