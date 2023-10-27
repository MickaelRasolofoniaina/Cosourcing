using Cosourcing.RH.Domain.Entite;

namespace Cosourcing.RH.Contracts.DataAccess.Affiliation
{
	public interface IAffiliationRepository
	{
		public Task<AffiliationModel[]> GetAllAffiliations();

		public Task<AffiliationModel[]> GetEtablissementAffiliations(int idEtablissement, int idOrganismeSocial);
    }
}

