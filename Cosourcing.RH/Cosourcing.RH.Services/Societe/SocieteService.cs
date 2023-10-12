using Cosourcing.RH.Contracts.DataAccess;
using Cosourcing.RH.Contracts.DataAccess.Societe;
using Cosourcing.RH.Contracts.Services.Societe;
using Cosourcing.RH.Domain.Entite;
using Cosourcing.RH.Domain.Exception;
using Cosourcing.RH.Utility;
using Cosourcing.RH.Utility.Validateur;

namespace Cosourcing.RH.Services.Societe
{
    public class SocieteService : ISocieteService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly ISocieteRepository _societeRepository;

        public SocieteService(
            IBaseRepository baseRepository,
            ISocieteRepository societeRepository
        )
        {
            _baseRepository = baseRepository;
            _societeRepository = societeRepository;
        }

        private static void ValiderSociete(SocieteModel societe)
        {
            if (!ValidateurGenerique.EstRenseigne(societe.RaisonSociale))
            {
                throw new InvalidModelDataException("Veuillez indiquer la raison sociale de la société");
            }

            if (!ValidateurGenerique.EstRenseigne(societe.NomCommercial))
            {
                throw new InvalidModelDataException("Veuillez indiquer le nom commerciale de la société");
            }

            if (!ValidateurGenerique.EstDatePassee(societe.DateDeCreation))
            {
                throw new InvalidModelDataException("La date de création de la société doit être dans le passé");
            }

            if (!ValidateurGenerique.EstRenseigne(societe.FormeJuridique))
            {
                throw new InvalidModelDataException("Veuillez indiquer la forme juridique de la société");
            }

            if (!ValidateurEntite.EstValideFormeJuridique(societe.FormeJuridique))
            {
                throw new InvalidModelDataException("Forme juridique invalide");
            }

            if (!ValidateurGenerique.EstRenseigne(societe.NumeroStatistique))
            {
                throw new InvalidModelDataException("Veuillez indiquer le numéro statistique de la société");
            }

            if (!ValidateurGenerique.EstChiffreUniquement(societe.NumeroStatistique))
            {
                throw new InvalidModelDataException("Numero statistique invalide, veuillez insérer un numéro statistique en chiffre uniquement");
            }

            if (!ValidateurGenerique.EstNChiffreUniquement(societe.Nif, 10))
            {
                throw new InvalidModelDataException("NIF invalide, veuillez insérer un NIF à 10 chiffres uniquement");
            }

            if (!ValidateurGenerique.EstRenseigne(societe.Activite))
            {
                throw new InvalidModelDataException("Veuillez indiquer l'activité de la société");
            }

            if (!ValidateurGenerique.EstPositif(societe.NombreEtablissement))
            {
                throw new InvalidModelDataException("Nombre établissement invalide, veuillez insérer un nombre positif uniquement");
            }
        }


        public Task<int> Save(SocieteModel societe)
        {
            ValiderSociete(societe);

            ValidateurEntite.ValiderEntite(societe);

            _baseRepository.Add(societe);

            return _baseRepository.SaveChangesAsync();
        }

        public ValueTask<SocieteModel?> GetById(int id)
        {
            return _baseRepository.GetById<SocieteModel>(id);
        }

        public Task<SocieteModel[]> GetAll()
        {
            return _societeRepository.GetAllSocietes();
        }

        public Task<int> DeleteSociete(int id)
        {
            _baseRepository.Delete<SocieteModel>(id);

            return _baseRepository.SaveChangesAsync();
        }

        public Task<bool> UpdateSociete(SocieteModel societe)
        {
            return _baseRepository.UpdateEntity(societe);
        }
    }
}

