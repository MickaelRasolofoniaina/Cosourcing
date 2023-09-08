using Cosourcing.RH.Domain;

namespace Cosourcing.RH.Contracts.DataAccess
{
	public interface IBaseRepository
	{
		public void Add<T>(T obj) where T : BaseModel;

        public void Delete<T>(Guid id) where T : BaseModel;

        public ValueTask<T?> GetById<T>(Guid id) where T : BaseModel;

        public void BeginTransaction();

        public void CommitTransaction();

        public void RollbackTransaction();
    }
}

