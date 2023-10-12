using Cosourcing.RH.Domain;

namespace Cosourcing.RH.Contracts.DataAccess
{
	public interface IBaseRepository
	{
		public void Add<T>(T obj) where T : BaseModel;

        public void Delete<T>(int id) where T : BaseModel;

        public ValueTask<T?> GetById<T>(int id) where T : BaseModel;

        public Task<int> SaveChangesAsync();

        public void BeginTransaction();

        public void CommitTransaction();

        public void RollbackTransaction();
        public Task<bool> UpdateEntity<T>(T model) where T: BaseModel;
    }
}

