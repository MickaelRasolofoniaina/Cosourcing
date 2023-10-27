using System.Linq.Expressions;
using Cosourcing.RH.Contracts.DataAccess;
using Cosourcing.RH.Contracts.DataAccess.OrganismeSocial;
using Cosourcing.RH.Contracts.Services.OrganismeSocial;
using Cosourcing.RH.Domain.Entite;
using Cosourcing.RH.Domain.Exception;
using Cosourcing.RH.Utility;
using Cosourcing.RH.Utility.Validateur;

namespace Cosourcing.RH.Services.OrganismeSocial
{
	public class OrganismeSocialService : IOrganismeSocialService
	{
		private readonly IBaseRepository _baseRepository;
		private readonly IOrganismeSocialRepository _organismeSocialRepository;

		public OrganismeSocialService(
			IBaseRepository baseRepository,
			IOrganismeSocialRepository organismeSocialRepository
		)
		{
			_baseRepository = baseRepository;
			_organismeSocialRepository = organismeSocialRepository;
		}

		private static void ValiderOrganismeSocial(OrganismeSocialModel organismeSocial)
		{
            ValidateurOrganismeSocial.ValiderOrganismeSocial(organismeSocial);
            if(!ValidateurOrganismeSocial.EstPositif(organismeSocial.BaseCotisationSocialeEmployeur)){
                throw new InvalidModelDataException("Base Cotisation Sociale invalide");
            }
            if(!ValidateurOrganismeSocial.EstPositif(organismeSocial.BaseCotisationSocialeSalarie)){
                throw new InvalidModelDataException("Base Cotisation Sociale Salarie invalide");
            }
            if(!ValidateurOrganismeSocial.EstPositif(organismeSocial.BaseTauxCotisationSocialeEmployeur)){
                throw new InvalidModelDataException("Base Taux Cotisation Sociale Employeur invalide");
            }
            if(!ValidateurOrganismeSocial.EstPositif(organismeSocial.BaseTauxCotisationSocialeSalarie)){
                throw new InvalidModelDataException("Base Taux Cotisation Sociale Salarie invalide");
            }
        }

        public Task<int> Save(OrganismeSocialModel organismeSocial)
        {
            ValiderOrganismeSocial(organismeSocial);
            _baseRepository.Add(organismeSocial);

			return _baseRepository.SaveChangesAsync();
        }


        public ValueTask<OrganismeSocialModel?> GetById(int id)
        {
            return _baseRepository.GetById<OrganismeSocialModel>(id);
        }

        public Task<OrganismeSocialModel[]> GetAll()
        {
            return _organismeSocialRepository.GetAllOrganismeSocials();
        }

        public Task<int> DeleteOrganismeSocial(int id)
        {
            _baseRepository.Delete<OrganismeSocialModel>(id);

            return _baseRepository.SaveChangesAsync();
        }

        public Task<OrganismeSocialModel[]> GetOrganismeSocials()
        {           
               
            return _organismeSocialRepository.GetAllOrganismeSocials();                          
            
        }

        public Task<bool> UpdateOrganismeSocial(OrganismeSocialModel organismeSocial){
            ValiderOrganismeSocial(organismeSocial);
            return _baseRepository.UpdateEntity(organismeSocial);
        }
    }
}

