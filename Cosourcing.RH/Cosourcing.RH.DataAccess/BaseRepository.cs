using Cosourcing.RH.Contracts.DataAccess;
using Cosourcing.RH.DataAccess.Context;
using Cosourcing.RH.Domain;
using Microsoft.EntityFrameworkCore;



namespace Cosourcing.RH.DataAccess
{
	public class BaseRepository : IBaseRepository
	{
		private readonly RHDbContext _rhDbContext;

		public BaseRepository(RHDbContext rHDbContext)
		{
			_rhDbContext = rHDbContext;
		}

		public Task<int> SaveChangesAsync()
		{
			return _rhDbContext.SaveChangesAsync();
		}

		public void BeginTransaction()
		{
			_rhDbContext.Database.BeginTransaction();
		}

		public void CommitTransaction()
		{
			_rhDbContext.Database.CommitTransaction();
		}

		public void RollbackTransaction()
		{
			_rhDbContext.Database.RollbackTransaction();
		}

		public void Add<T>(T obj) where T : BaseModel
		{
			_rhDbContext.Add(obj);
		}

		public ValueTask<T?> GetById<T>(int id) where T : BaseModel
		{
			return _rhDbContext.FindAsync<T>(id);

		}

		public async void Delete<T>(int id) where T : BaseModel
		{
			var entity = await GetById<T>(id);



			if (entity != null)
			{
				entity.Deleted = true;
			}
		}
		public async Task<bool> UpdateEntity<T>(T model) where T : BaseModel
		{

			var objet = await _rhDbContext.FindAsync<T>(model.Id);
			if (objet != null)
			{
				try
				{
					_rhDbContext.Entry(objet).CurrentValues.SetValues(model);
					await _rhDbContext.SaveChangesAsync();
					return true;
				}
				catch (DbUpdateConcurrencyException)
				{
					throw;
				}
			}
			return false;
		}
	}
}

