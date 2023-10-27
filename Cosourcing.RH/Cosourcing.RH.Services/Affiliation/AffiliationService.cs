using System.Linq.Expressions;
using Cosourcing.RH.Contracts.DataAccess;
using Cosourcing.RH.Contracts.DataAccess.Affiliation;
using Cosourcing.RH.Contracts.Services.Affiliation;
using Cosourcing.RH.Domain.Entite;
using Cosourcing.RH.Domain.Exception;
using Cosourcing.RH.Utility;
using Cosourcing.RH.Utility.Validateur;

namespace Cosourcing.RH.Services.Affiliation
{
	public class AffiliationService : IAffiliationService
	{
		private readonly IBaseRepository _baseRepository;
		private readonly IAffiliationRepository _affiliationRepository;

		public AffiliationService(
			IBaseRepository baseRepository,
			IAffiliationRepository affiliationRepository
		)
		{
			_baseRepository = baseRepository;
			_affiliationRepository = affiliationRepository;
		}

		private static void ValiderAffiliation(AffiliationModel affiliation)
		{
            if (affiliation.IdEtablissement < 1 || affiliation.IdOrganismeSocial < 1 )
            {
                throw new InvalidModelDataException("identifiant negative ou null");
            }  
                     

        }

        public Task<int> Save(AffiliationModel affiliation)
        {
            ValiderAffiliation(affiliation);
            _baseRepository.Add(affiliation);

			return _baseRepository.SaveChangesAsync();
        }


        public ValueTask<AffiliationModel?> GetById(int id)
        {
            return _baseRepository.GetById<AffiliationModel>(id);
        }

        public Task<AffiliationModel[]> GetAll()
        {
            return _affiliationRepository.GetAllAffiliations();
        }

        public Task<int> DeleteAffiliation(int id)
        {
            _baseRepository.Delete<AffiliationModel>(id);

            return _baseRepository.SaveChangesAsync();
        }

        public Task<AffiliationModel[]> GetEtablissementAffiliations(int idEtablissement, int idOrganismeSocial)
        {   
          
                if(idEtablissement != -1 && idOrganismeSocial != -1){
                    return _affiliationRepository.GetEtablissementAffiliations(idEtablissement, idOrganismeSocial);
                }
                else{
                    return _affiliationRepository.GetAllAffiliations();
                }           
            
        }

        public Task<bool> UpdateAffiliation(AffiliationModel affiliation){
            ValiderAffiliation(affiliation);
            return _baseRepository.UpdateEntity(affiliation);
        }
    }
}

