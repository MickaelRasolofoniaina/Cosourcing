using Cosourcing.RH.Contracts.DataAccess.ServiceImpot;
using Cosourcing.RH.Domain.Entite;
using Microsoft.EntityFrameworkCore;

namespace Cosourcing.RH.DataAccess.ServiceImpot
{
	public class ServiceImpotRepository : IServiceImpotRepository
	{
        private readonly DbSet<ServiceImpotModel> _serviceImpotDbContext;

		public ServiceImpotRepository(DbSet<ServiceImpotModel> serviceImpotDbContext)
		{
            _serviceImpotDbContext = serviceImpotDbContext;
        }

        public Task<ServiceImpotModel[]> GetAllServiceImpots()
        {
            return _serviceImpotDbContext
                .Where(e => !e.Deleted )
                .ToArrayAsync();
        }

    }
}

