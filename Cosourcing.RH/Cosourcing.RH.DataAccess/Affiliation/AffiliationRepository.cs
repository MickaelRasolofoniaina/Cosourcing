using Cosourcing.RH.Contracts.DataAccess.Affiliation;
using Cosourcing.RH.Domain.Entite;
using Microsoft.EntityFrameworkCore;

namespace Cosourcing.RH.DataAccess.Affiliation
{
	public class AffiliationRepository : IAffiliationRepository
	{
        private readonly DbSet<AffiliationModel> _affiliationDbContext;

		public AffiliationRepository(DbSet<AffiliationModel> affiliationDbContext)
		{
            _affiliationDbContext = affiliationDbContext;
        }

        public Task<AffiliationModel[]> GetAllAffiliations()
        {
            return _affiliationDbContext
                .Where(e => !e.Deleted )
                .ToArrayAsync();
        }

        public Task<AffiliationModel[]> GetEtablissementAffiliations(int idEtablissement, int idOrganismeSocial)
        {
            return _affiliationDbContext
                .Where(e => !e.Deleted && e.IdEtablissement == idEtablissement && e.IdOrganismeSocial == idOrganismeSocial)
                .ToArrayAsync();
        }
    }
}

