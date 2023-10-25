using System.Linq.Expressions;
using Cosourcing.RH.Contracts.DataAccess;
using Cosourcing.RH.Contracts.DataAccess.ServiceImpot;
using Cosourcing.RH.Contracts.Services.ServiceImpot;
using Cosourcing.RH.Domain.Entite;
using Cosourcing.RH.Domain.Exception;
using Cosourcing.RH.Utility;
using Cosourcing.RH.Utility.Validateur;

namespace Cosourcing.RH.Services.ServiceImpot
{
	public class ServiceImpotService : IServiceImpotService
	{
		private readonly IBaseRepository _baseRepository;
		private readonly IServiceImpotRepository _serviceImpotRepository;

		public ServiceImpotService(
			IBaseRepository baseRepository,
			IServiceImpotRepository serviceImpotRepository
		)
		{
			_baseRepository = baseRepository;
			_serviceImpotRepository = serviceImpotRepository;
		}

		private static void ValiderServiceImpot(ServiceImpotModel serviceImpot)
		{
            ValidateurServiceImpot.ValiderServiceImpot(serviceImpot);
            
            if(!ValidateurServiceImpot.EstPositif(serviceImpot.BaseCotisationImposableEmployeur)){
                throw new InvalidModelDataException("Base Cotisation Imposable Employeur invalide");
            }
            if(!ValidateurServiceImpot.EstPositif(serviceImpot.BaseCotisationImposableSalarie)){
                throw new InvalidModelDataException("Base Cotisation Imposable Salarie invalide");
            }
            if(!ValidateurServiceImpot.EstPositif(serviceImpot.BaseTauxImpotEmployeur)){
                throw new InvalidModelDataException("Base Taux Impot Employeur invalide");
            }
            if(!ValidateurServiceImpot.EstPositif(serviceImpot.BaseTauxImpotSalarie)){
                throw new InvalidModelDataException("Base Taux ImpotS alarie invalide");
            }if(!ValidateurServiceImpot.EstPositif(serviceImpot.ReductionImpot)){
                throw new InvalidModelDataException("Reduction Impot invalide");
            }
        }

        public Task<int> Save(ServiceImpotModel serviceImpot)
        {
            ValiderServiceImpot(serviceImpot);
            _baseRepository.Add(serviceImpot);

			return _baseRepository.SaveChangesAsync();
        }


        public ValueTask<ServiceImpotModel?> GetById(int id)
        {
            return _baseRepository.GetById<ServiceImpotModel>(id);
        }

        public Task<ServiceImpotModel[]> GetAll()
        {
            return _serviceImpotRepository.GetAllServiceImpots();
        }

        public Task<int> DeleteServiceImpot(int id)
        {
            _baseRepository.Delete<ServiceImpotModel>(id);

            return _baseRepository.SaveChangesAsync();
        }

        public Task<ServiceImpotModel[]> GetEtablissementServiceImpots(int idEtablissement)
        {   
          
                if(idEtablissement != -1){
                    return _serviceImpotRepository.GetEtablissementServiceImpots(idEtablissement);
                }
                else{
                    return _serviceImpotRepository.GetAllServiceImpots();
                }           
            
        }

        public Task<bool> UpdateServiceImpot(ServiceImpotModel serviceImpot){
            ValiderServiceImpot(serviceImpot);
            return _baseRepository.UpdateEntity(serviceImpot);
        }
    }
}

