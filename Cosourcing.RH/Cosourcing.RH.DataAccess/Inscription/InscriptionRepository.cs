using Cosourcing.RH.Contracts.DataAccess.Inscription;
using Cosourcing.RH.Domain.Entite;
using Microsoft.EntityFrameworkCore;

namespace Cosourcing.RH.DataAccess.Inscription
{
	public class InscriptionRepository : IInscriptionRepository
	{
        private readonly DbSet<InscriptionModel> _affiliationDbContext;

		public InscriptionRepository(DbSet<InscriptionModel> affiliationDbContext)
		{
            _affiliationDbContext = affiliationDbContext;
        }

        public Task<InscriptionModel[]> GetAllInscriptions()
        {
            return _affiliationDbContext
                .Where(e => !e.Deleted )
                .ToArrayAsync();
        }

        public Task<InscriptionModel[]> GetEtablissementInscriptions(int idEtablissement, int idServiceImpot)
        {
            return _affiliationDbContext
                .Where(e => !e.Deleted && e.IdEtablissement == idEtablissement && e.IdServiceImpot == idServiceImpot)
                .ToArrayAsync();
        }
    }
}

