using Cosourcing.RH.Domain.Entite;

namespace Cosourcing.RH.Contracts.DataAccess.Inscription
{
	public interface IInscriptionRepository
	{
		public Task<InscriptionModel[]> GetAllInscriptions();

		public Task<InscriptionModel[]> GetEtablissementInscriptions(int idEtablissement, int idServiceImpot);
    }
}

