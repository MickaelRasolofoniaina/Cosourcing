using Cosourcing.RH.Contracts.DataAccess.User;
using Cosourcing.RH.DataAccess.Context;
using Cosourcing.RH.Domain.User;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Cosourcing.RH.DataAccess.User
{
	public class UserRepository : IUserRepository
	{
        private readonly DbSet<UserModel> _userDbContext;

		public UserRepository(DbSet<UserModel> userDbContext)
		{
            _userDbContext = userDbContext;
        }

        public Task<UserModel[]> GetAllUsers()
        {
            return _userDbContext.ToArrayAsync();
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
           
            return await _userDbContext.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}

