using Cosourcing.RH.Domain.Entite;

namespace Cosourcing.RH.Contracts.Services.Affiliation
{
	public interface IAffiliationService
	{
		public Task<int> Save(AffiliationModel affiliation);

        public ValueTask<AffiliationModel?> GetById(int id);

        public Task<AffiliationModel[]> GetAll();

        public Task<int> DeleteAffiliation(int id);

        public Task<AffiliationModel[]> GetEtablissementAffiliations(int idEtablissement, int idOrganismeSocial);
        public Task<bool> UpdateAffiliation(AffiliationModel affiliation);
    }
}

