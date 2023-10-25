using Cosourcing.RH.Contracts.DataAccess.OrganismeSocial;
using Cosourcing.RH.Domain.Entite;
using Microsoft.EntityFrameworkCore;

namespace Cosourcing.RH.DataAccess.OrganismeSocial
{
	public class OrganismeSocialRepository : IOrganismeSocialRepository
	{
        private readonly DbSet<OrganismeSocialModel> _organismeSocialDbContext;

		public OrganismeSocialRepository(DbSet<OrganismeSocialModel> organismeSocialDbContext)
		{
            _organismeSocialDbContext = organismeSocialDbContext;
        }

        public Task<OrganismeSocialModel[]> GetAllOrganismeSocials()
        {
            return _organismeSocialDbContext
                .Where(e => !e.Deleted )
                .ToArrayAsync();
        }

        public Task<OrganismeSocialModel[]> GetEtablissementOrganismeSocials(int idEtablissement)
        {
            return _organismeSocialDbContext
                .Where(e => !e.Deleted && e.IdEtablissement == idEtablissement)
                .ToArrayAsync();
        }
    }
}

