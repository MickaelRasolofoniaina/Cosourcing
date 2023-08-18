using System;
using Cosourcing.RH.Contracts.DataAccess;
using Cosourcing.RH.Contracts.DataAccess.User;
using Cosourcing.RH.Contracts.Services.User;
using Cosourcing.RH.Domain.User;
using Cosourcing.RH.Domain.Exception;

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

		private static void ValidateData(UserModel user)
		{
            if (!user.Email.Contains("@gmail.com"))
            {
                throw new InvalidModelDataException("Please enter gmail");
            }
        }

        public Task<int> Save(UserModel user)
        {
            ValidateData(user);

            _baseRepository.Add<UserModel>(user);

			return _baseRepository.Commit();
        }

        public async Task<int> UpdateEmail(Guid id, string email)
        {
            if(String.IsNullOrEmpty(email))
            {
                throw new InvalidModelDataException("Email required");
            }

            var user = await _baseRepository.GetById<UserModel>(id);

            if(user != null)
            {
                user.Email = email;

                return await _baseRepository.Commit();
            }
            else
            {
                throw new EntityNotFoundException($"Cannot find user with {id}");
            }
        }

        public ValueTask<UserModel?> GetById(Guid id)
        {
            return _baseRepository.GetById<UserModel>(id);
        }

        public Task<UserModel[]> GetAll()
        {
            return _userRepository.GetAllUsers();
        }

        public Task<int> DeleteUser(Guid id)
        {
            _baseRepository.Delete<UserModel>(id);

            return _baseRepository.Commit();
        }
    }
}

