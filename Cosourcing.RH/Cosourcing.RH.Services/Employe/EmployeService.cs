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
          
            if (!ValidateurEmploye.EstValideSituation(employe.Situation))
            {
                throw new InvalidModelDataException("situation invalide");
            }
            if (!ValidateurEmploye.EstValideMotifSortie(employe.MotifSortie))
            {
                throw new InvalidModelDataException("Motif de sortie invalide");
            }
            if (!ValidateurEmploye.EstValideTypeContrat(employe.TypeContrat))
            {
                throw new InvalidModelDataException("Type de contrat invalide");
            }
            if (!ValidateurEmploye.EstValideModeReglement(employe.ModeReglement))
            {
                throw new InvalidModelDataException("Mode de règlement invalide");
            }
            if (!ValidateurEmploye.EstValideGenre(employe.Genre))
            {
                throw new InvalidModelDataException("Genre invalide");
            }
            if (!ValidateurEmploye.EstValidePoste(employe.Poste))
            {
                throw new InvalidModelDataException("Poste invalide");
            }
            if (!ValidateurEmploye.EstValideCategorie(employe.Categorie))
            {
                throw new InvalidModelDataException("Catégorie invalide");
            }
            if (!ValidateurEmploye.EstValideGroupe(employe.Groupe))
            {
                throw new InvalidModelDataException("Groupe invalide");
            }
            if(!ValidateurEmploye.EstValidePays(employe.PaysNaissance)){
                throw new InvalidModelDataException("pays de naissance non valide");
            }
            if(!ValidateurEmploye.EstValidePays(employe.PaysNationalite)){
                throw new InvalidModelDataException("pays de nationalité non valide");
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

