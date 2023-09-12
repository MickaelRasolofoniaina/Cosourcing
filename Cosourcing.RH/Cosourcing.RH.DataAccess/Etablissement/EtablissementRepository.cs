using Cosourcing.RH.Contracts.DataAccess.Etablissement;
using Cosourcing.RH.Domain.Entite;
using Microsoft.EntityFrameworkCore;

namespace Cosourcing.RH.DataAccess.Etablissement
{
	public class EtablissementRepository : IEtablissementRepository
	{
        private readonly DbSet<EtablissementModel> _etablissementDbContext;

		public EtablissementRepository(DbSet<EtablissementModel> etablissementDbContext)
		{
            _etablissementDbContext = etablissementDbContext;
        }

        public Task<EtablissementModel[]> GetAllEtablissements()
        {
            return _etablissementDbContext
                .Where(e => !e.Deleted )
                .ToArrayAsync();
        }

        public Task<EtablissementModel[]> GetSocieteEtablissements(int idSociete)
        {
            return _etablissementDbContext
                .Where(e => !e.Deleted && e.IdSociete == idSociete)
                .ToArrayAsync();
        }
    }
}

