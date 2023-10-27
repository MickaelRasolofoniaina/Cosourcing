using Cosourcing.RH.Domain.Entite;

namespace Cosourcing.RH.Contracts.Services.Inscription
{
	public interface IInscriptionService
	{
		public Task<int> Save(InscriptionModel affiliation);

        public ValueTask<InscriptionModel?> GetById(int id);

        public Task<InscriptionModel[]> GetAll();

        public Task<int> DeleteInscription(int id);

        public Task<InscriptionModel[]> GetEtablissementInscriptions(int idEtablissement, int idServiceImpot);
        public Task<bool> UpdateInscription(InscriptionModel affiliation);
    }
}

