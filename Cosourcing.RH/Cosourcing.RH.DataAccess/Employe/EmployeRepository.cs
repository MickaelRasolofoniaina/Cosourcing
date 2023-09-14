using Cosourcing.RH.Contracts.DataAccess.Employe;
using Cosourcing.RH.Domain.Entite;
using Microsoft.EntityFrameworkCore;

namespace Cosourcing.RH.DataAccess.Employe
{
	public class EmployeRepository : IEmployeRepository
	{
        private readonly DbSet<EmployeModel> _etablissementDbContext;

		public EmployeRepository(DbSet<EmployeModel> etablissementDbContext)
		{
            _etablissementDbContext = etablissementDbContext;
        }

        public Task<EmployeModel[]> GetAllEmployes()
        {
            return _etablissementDbContext
                .Where(e => !e.Deleted )
                .ToArrayAsync();
        }

        public Task<EmployeModel[]> GetEtablissementEmployes(int idEtablissement)
        {
            return _etablissementDbContext
                .Where(e => !e.Deleted && e.IdEtablissement == idEtablissement)
                .ToArrayAsync();
        }
    }
}

