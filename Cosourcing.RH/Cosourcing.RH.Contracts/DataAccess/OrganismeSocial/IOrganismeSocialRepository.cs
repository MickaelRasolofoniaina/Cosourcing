using Cosourcing.RH.Domain.Entite;

namespace Cosourcing.RH.Contracts.DataAccess.OrganismeSocial
{
	public interface IOrganismeSocialRepository
	{
		public Task<OrganismeSocialModel[]> GetAllOrganismeSocials();

		public Task<OrganismeSocialModel[]> GetEtablissementOrganismeSocials(int idEtablissement);
    }
}

