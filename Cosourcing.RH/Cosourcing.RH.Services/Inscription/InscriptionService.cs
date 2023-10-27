using System.Linq.Expressions;
using Cosourcing.RH.Contracts.DataAccess;
using Cosourcing.RH.Contracts.DataAccess.Inscription;
using Cosourcing.RH.Contracts.Services.Inscription;
using Cosourcing.RH.Domain.Entite;
using Cosourcing.RH.Domain.Exception;
using Cosourcing.RH.Utility;
using Cosourcing.RH.Utility.Validateur;

namespace Cosourcing.RH.Services.Inscription
{
	public class InscriptionService : IInscriptionService
	{
		private readonly IBaseRepository _baseRepository;
		private readonly IInscriptionRepository _inscriptionRepository;

		public InscriptionService(
			IBaseRepository baseRepository,
			IInscriptionRepository inscriptionRepository
		)
		{
			_baseRepository = baseRepository;
			_inscriptionRepository = inscriptionRepository;
		}

		private static void ValiderInscription(InscriptionModel inscription)
		{
            if (inscription.IdEtablissement < 1 || inscription.IdServiceImpot < 1 )
            {
                throw new InvalidModelDataException("identifiant negative ou null");
            }  
                     

        }

        public Task<int> Save(InscriptionModel inscription)
        {
            ValiderInscription(inscription);
            _baseRepository.Add(inscription);

			return _baseRepository.SaveChangesAsync();
        }


        public ValueTask<InscriptionModel?> GetById(int id)
        {
            return _baseRepository.GetById<InscriptionModel>(id);
        }

        public Task<InscriptionModel[]> GetAll()
        {
            return _inscriptionRepository.GetAllInscriptions();
        }

        public Task<int> DeleteInscription(int id)
        {
            _baseRepository.Delete<InscriptionModel>(id);

            return _baseRepository.SaveChangesAsync();
        }

        public Task<InscriptionModel[]> GetEtablissementInscriptions(int idEtablissement, int idServiceImpot)
        {   
          
                if(idEtablissement != -1 && idServiceImpot != -1){
                    return _inscriptionRepository.GetEtablissementInscriptions(idEtablissement, idServiceImpot);
                }
                else{
                    return _inscriptionRepository.GetAllInscriptions();
                }           
            
        }

        public Task<bool> UpdateInscription(InscriptionModel inscription){
            ValiderInscription(inscription);
            return _baseRepository.UpdateEntity(inscription);
        }
    }
}

