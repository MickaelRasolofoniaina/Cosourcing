using Cosourcing.RH.Contracts.DataAccess;
using Cosourcing.RH.Contracts.DataAccess.Etablissement;
using Cosourcing.RH.Contracts.Services.Etablissement;
using Cosourcing.RH.Domain.Entite;
using Cosourcing.RH.Domain.Exception;
using Cosourcing.RH.Utility;
using Cosourcing.RH.Utility.Validateur;

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

		private static void ValiderEtablissement(EtablissementModel etablissement)
		{
            if (!ValidateurGenerique.EstRenseigne(etablissement.Nom))
            {
                throw new InvalidModelDataException("Veuillez indiquer le nom de l'établissement");
            }

            if (!ValidateurGenerique.EstRenseigne(etablissement.Adresse))
            {
                throw new InvalidModelDataException("Veuillez indiquer l'addresse de l'établissement");
            }

            if (!ValidateurGenerique.EstRenseigne(etablissement.Activite))
            {
                throw new InvalidModelDataException("Veuillez indiquer l'activité de l'établissement");
            }
        }

        public Task<int> Save(EtablissementModel etablissement)
        {
            ValiderEtablissement(etablissement);

            ValidateurEntite.ValiderEntite(etablissement);

            _baseRepository.Add(etablissement);

			return _baseRepository.SaveChangesAsync();
        }


        public ValueTask<EtablissementModel?> GetById(int id)
        {
            return _baseRepository.GetById<EtablissementModel>(id);
        }

        public Task<EtablissementModel[]> GetAll()
        {
            return _etablissementRepository.GetAllEtablissements();
        }

        public Task<int> DeleteEtablissement(int id)
        {
            _baseRepository.Delete<EtablissementModel>(id);

            return _baseRepository.SaveChangesAsync();
        }
    }
}

