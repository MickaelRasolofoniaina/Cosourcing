using Cosourcing.RH.Contracts.DataAccess.Employe;
using Cosourcing.RH.Domain.Entite;
using Microsoft.EntityFrameworkCore;

namespace Cosourcing.RH.DataAccess.Employe
{
	public class EmployeRepository : IEmployeRepository
	{
        private readonly DbSet<EmployeModel> _employeDbContext;

		public EmployeRepository(DbSet<EmployeModel> employeDbContext)
		{
            _employeDbContext = employeDbContext;
        }

        public Task<EmployeModel[]> GetAllEmployes()
        {
            return _employeDbContext
                .Where(e => !e.Deleted )
                .ToArrayAsync();
        }

        public Task<EmployeModel[]> GetEtablissementEmployes(int idEtablissement)
        {
            return _employeDbContext
                .Where(e => !e.Deleted && e.IdEtablissement == idEtablissement)
                .ToArrayAsync();
        }
    }
}

