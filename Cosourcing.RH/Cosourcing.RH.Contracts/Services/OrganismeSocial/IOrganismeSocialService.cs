using Cosourcing.RH.Domain.Entite;

namespace Cosourcing.RH.Contracts.Services.OrganismeSocial
{
	public interface IOrganismeSocialService
	{
		public Task<int> Save(OrganismeSocialModel organismeSocial);

        public ValueTask<OrganismeSocialModel?> GetById(int id);

        public Task<OrganismeSocialModel[]> GetAll();

        public Task<int> DeleteOrganismeSocial(int id);

        public Task<OrganismeSocialModel[]> GetEtablissementOrganismeSocials(int idEtablissement);
        public Task<bool> UpdateOrganismeSocial(OrganismeSocialModel organismeSocial);
    }
}

