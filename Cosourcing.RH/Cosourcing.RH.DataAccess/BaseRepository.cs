using System;
using Cosourcing.RH.Contracts.DataAccess;
using Cosourcing.RH.DataAccess.Context;
using Cosourcing.RH.Domain;
using Cosourcing.RH.Domain.Exception;
using Npgsql.TypeMapping;

namespace Cosourcing.RH.DataAccess
{
	public class BaseRepository : IBaseRepository
	{
        private RHDbContext _rhDbContext;

        public BaseRepository(RHDbContext rHDbContext)
		{
			_rhDbContext = rHDbContext;
		}

		public Task<int> Commit()
		{
			return _rhDbContext.SaveChangesAsync();
		}

		public void Add<T>(T obj) where T : BaseModel
		{
			obj.Id = Guid.NewGuid();

			_rhDbContext.Add<T>(obj);
		}

        public ValueTask<T?> GetById<T>(Guid id) where T : BaseModel
		{
			return _rhDbContext.FindAsync<T>(id);

		}

        public async void Delete<T>(Guid id) where T : BaseModel
        {
			var entity = await GetById<T>(id);

			if(entity != null)
			{
                entity.Deleted = true;
            }
        }
    }
}

