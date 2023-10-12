using System.Linq.Expressions;
using Cosourcing.RH.Contracts.DataAccess;
using Cosourcing.RH.Contracts.DataAccess.Employe;
using Cosourcing.RH.Contracts.Services.Employe;
using Cosourcing.RH.Domain.Entite;
using Cosourcing.RH.Domain.Exception;
using Cosourcing.RH.Utility;
using Cosourcing.RH.Utility.Validateur;

namespace Cosourcing.RH.Services.Employe
{
	public class EmployeService : IEmployeService
	{
		private readonly IBaseRepository _baseRepository;
		private readonly IEmployeRepository _employeRepository;

		public EmployeService(
			IBaseRepository baseRepository,
			IEmployeRepository employeRepository
		)
		{
			_baseRepository = baseRepository;
			_employeRepository = employeRepository;
		}

		private static void ValiderEmploye(EmployeModel employe)
		{
            if (!ValidateurEmploye.ValiderEmploye(employe))
            {
                throw new InvalidModelDataException("Veuillez indiquer tous les champs obligatoire");
            }           

        }

        public Task<int> Save(EmployeModel employe)
        {
            ValiderEmploye(employe);
            _baseRepository.Add(employe);

			return _baseRepository.SaveChangesAsync();
        }


        public ValueTask<EmployeModel?> GetById(int id)
        {
            return _baseRepository.GetById<EmployeModel>(id);
        }

        public Task<EmployeModel[]> GetAll()
        {
            return _employeRepository.GetAllEmployes();
        }

        public Task<int> DeleteEmploye(int id)
        {
            _baseRepository.Delete<EmployeModel>(id);

            return _baseRepository.SaveChangesAsync();
        }

        public Task<EmployeModel[]> GetEtablissementEmployes(int idEtablissement)
        {   
          
                if(idEtablissement != -1){
                    return _employeRepository.GetEtablissementEmployes(idEtablissement);
                }
                else{
                    return _employeRepository.GetAllEmployes();
                }           
            
        }

        public Task<bool> UpdateEmploye(EmployeModel employe){
            ValiderEmploye(employe);
            return _baseRepository.UpdateEntity(employe);
        }
    }
}

