using Cosourcing.RH.Domain.Entite;
using Cosourcing.RH.Domain.Exception;

namespace Cosourcing.RH.Utility.Validateur
{
	public static class ValidateurEntite
	{
		public static void ValiderEntite(BaseEntite baseEntite)
		{
            if (!ValidateurGenerique.EstRenseigne(baseEntite.NomResponsable))
            {
                throw new InvalidModelDataException("Veuillez indiquer le nom du responsable de l'établissement");
            }

            if (!ValidateurGenerique.EstNomPersonneValide(baseEntite.NomResponsable))
            {
                throw new InvalidModelDataException("Le nom du responsable de l'établissement n'est pas valide");
            }

            if (ValidateurGenerique.EstRenseigne(baseEntite.PrenomResponsable) && !ValidateurGenerique.EstNomPersonneValide(baseEntite.PrenomResponsable))
            {
                throw new InvalidModelDataException("Le prénom du responsable de l'établissement n'est pas valide");
            }

            if (!ValidateurGenerique.EstRenseigne(baseEntite.QualiteResponsable))
            {
                throw new InvalidModelDataException("Veuillez indiquer la qualité du responsable de l'établissement");
            }

            if (ValidateurGenerique.EstRenseigne(baseEntite.CodeBanque1) && !ValidateurGenerique.EstNChiffreUniquement(baseEntite.CodeBanque1, 2))
            {
                throw new InvalidModelDataException("Code banque invalide, veuillez insérer un code à 2 chiffres uniquement");
            }

            if (ValidateurGenerique.EstRenseigne(baseEntite.Iban1) && !ValidateurGenerique.EstNChiffreUniquement(baseEntite.Iban1, 23))
            {
                throw new InvalidModelDataException("Iban invalide, veuillez insérer un code à 23 chiffres uniquement");
            }

            if (ValidateurGenerique.EstRenseigne(baseEntite.CodeBanque2) && !ValidateurGenerique.EstNChiffreUniquement(baseEntite.CodeBanque2, 2))
            {
                throw new InvalidModelDataException("Code banque invalide, veuillez insérer un code à 2 chiffres uniquement");
            }

            if (ValidateurGenerique.EstRenseigne(baseEntite.Iban2) && !ValidateurGenerique.EstNChiffreUniquement(baseEntite.Iban2, 23))
            {
                throw new InvalidModelDataException("Iban invalide, veuillez insérer un code à 23 chiffres uniquement");
            }

            if (!ValidateurGenerique.EstRenseigne(baseEntite.NomOrganismeSociale))
            {
                throw new InvalidModelDataException("Veuillez insérer le nom de l'organisme social de l'établissement");
            }

            if (!ValidateurGenerique.EstRenseigne(baseEntite.NumeroOrganismeSociale))
            {
                throw new InvalidModelDataException("Veuillez insérer le numéro d'affiliation de l'organisme social de l'établissement");
            }

            if (!ValidateurGenerique.EstRenseigne(baseEntite.NomServiceImpots))
            {
                throw new InvalidModelDataException("Veuillez insérer le nom du service impôt de l'établissement");
            }

            if (!ValidateurGenerique.EstRenseigne(baseEntite.NumeroAffiliationImpots))
            {
                throw new InvalidModelDataException("Veuillez insérer le numéro d'affiliation du service impôt de l'établissement");
            }
        }
	}
}

