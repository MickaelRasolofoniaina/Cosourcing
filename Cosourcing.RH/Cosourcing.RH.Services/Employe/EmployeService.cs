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
            if (!ValidateurGenerique.EstRenseigne(employe.Nom))
            {
                throw new InvalidModelDataException("Veuillez indiquer le nom de l'employé");
            }

            if (!ValidateurGenerique.EstRenseigne(employe.Adresse))
            {
                throw new InvalidModelDataException("Veuillez indiquer l'Adresse de l'employé");
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
            return _employeRepository.GetEtablissementEmployes(idEtablissement);
        }

        public Task<bool> UpdateEmploye(int id, EmployeModel employe){
            ValiderEmploye(employe);
            return _baseRepository.UpdateEntity(id, employe);
        }
    }
}

