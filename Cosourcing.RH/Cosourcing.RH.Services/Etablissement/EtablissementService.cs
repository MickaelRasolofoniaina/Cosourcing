using Cosourcing.RH.Contracts.DataAccess;
using Cosourcing.RH.Contracts.DataAccess.Etablissement;
using Cosourcing.RH.Contracts.Services.Etablissement;
using Cosourcing.RH.Domain.Etablissement;
using Cosourcing.RH.Domain.Exception;
using Cosourcing.RH.Utility;

namespace Cosourcing.RH.Services.Etablissement
{
	public class EtablissementService : IEtablissementService
	{
		private readonly IBaseRepository _baseRepository;
		private readonly IEtablissementRepository _etablissementRepository;

		public EtablissementService(
			IBaseRepository baseRepository,
			IEtablissementRepository etablissementRepository
		)
		{
			_baseRepository = baseRepository;
			_etablissementRepository = etablissementRepository;
		}

		private static void ValidateData(EtablissementModel etablissement)
		{
            if (!Validator.EstRenseigne(etablissement.Nom))
            {
                throw new InvalidModelDataException("Veuillez indiquer le nom de l'établissement");
            }

            if (!Validator.EstRenseigne(etablissement.Addresse))
            {
                throw new InvalidModelDataException("Veuillez indiquer l'addresse de l'établissement");
            }

            if (!Validator.EstRenseigne(etablissement.Activite))
            {
                throw new InvalidModelDataException("Veuillez indiquer l'activité de l'établissement");
            }

            if (!Validator.EstRenseigne(etablissement.NomResponsable))
            {
                throw new InvalidModelDataException("Veuillez indiquer le nom du responsable de l'établissement");
            }

            if (!Validator.EstNomPersonneValide(etablissement.NomResponsable))
            {
                throw new InvalidModelDataException("Le nom du responsable de l'établissement n'est pas valide");
            }

            if (Validator.EstRenseigne(etablissement.PrenomResponsable) && !Validator.EstNomPersonneValide(etablissement.PrenomResponsable))
            {
                throw new InvalidModelDataException("Le prénom du responsable de l'établissement n'est pas valide");
            }

            if (!Validator.EstRenseigne(etablissement.QualiteResponsable))
            {
                throw new InvalidModelDataException("Veuillez indiquer la qualité du responsable de l'établissement");
            }

            if(Validator.EstRenseigne(etablissement.CodeBanque1) && !Validator.EstNChiffreUniquement(etablissement.CodeBanque1, 2))
            {
                throw new InvalidModelDataException("Code banque invalide, veuillez insérer un code à 2 chiffres uniquement");
            }

            if (Validator.EstRenseigne(etablissement.Iban1) && !Validator.EstNChiffreUniquement(etablissement.Iban1, 23))
            {
                throw new InvalidModelDataException("Iban invalide, veuillez insérer un code à 23 chiffres uniquement");
            }

            if (Validator.EstRenseigne(etablissement.CodeBanque2) && !Validator.EstNChiffreUniquement(etablissement.CodeBanque2, 2))
            {
                throw new InvalidModelDataException("Code banque invalide, veuillez insérer un code à 2 chiffres uniquement");
            }

            if (Validator.EstRenseigne(etablissement.Iban2) && !Validator.EstNChiffreUniquement(etablissement.Iban2, 23))
            {
                throw new InvalidModelDataException("Iban invalide, veuillez insérer un code à 23 chiffres uniquement");
            }

            if (!Validator.EstPositif(etablissement.NombreEtablissement))
            {
                throw new InvalidModelDataException("Nombre établissement invalide, veuillez insérer un nombre positif uniquement");
            }

            if (!Validator.EstRenseigne(etablissement.NomOrganismeSociale))
            {
                throw new InvalidModelDataException("Veuillez insérer le nom de l'organisme social de l'établissement");
            }

            if (!Validator.EstRenseigne(etablissement.NumeroOrganismeSociale))
            {
                throw new InvalidModelDataException("Veuillez insérer le numéro d'affiliation de l'organisme social de l'établissement");
            }

            if (!Validator.EstRenseigne(etablissement.NomServiceImpots))
            {
                throw new InvalidModelDataException("Veuillez insérer le nom du service impôt de l'établissement");
            }

            if (!Validator.EstRenseigne(etablissement.NumeroAffiliationImpots))
            {
                throw new InvalidModelDataException("Veuillez insérer le numéro d'affiliation du service impôt de l'établissement");
            }
        }

        public Task<int> Save(EtablissementModel etablissement)
        {
            ValidateData(etablissement);

            _baseRepository.Add(etablissement);

			return _baseRepository.Commit();
        }


        public ValueTask<EtablissementModel?> GetById(Guid id)
        {
            return _baseRepository.GetById<EtablissementModel>(id);
        }

        public Task<EtablissementModel[]> GetAll()
        {
            return _etablissementRepository.GetAllEtablissements();
        }

        public Task<int> DeleteEtablissement(Guid id)
        {
            _baseRepository.Delete<EtablissementModel>(id);

            return _baseRepository.Commit();
        }
    }
}

