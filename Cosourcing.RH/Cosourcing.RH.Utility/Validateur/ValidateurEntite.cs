using System.Net.Sockets;
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
                throw new InvalidModelDataException("Veuillez indiquer le nom du responsable");
            }

            if (!ValidateurGenerique.EstNomPersonneValide(baseEntite.NomResponsable))
            {
                throw new InvalidModelDataException("Le nom du responsable n'est pas valide");
            }

            if (ValidateurGenerique.EstRenseigne(baseEntite.PrenomResponsable) && !ValidateurGenerique.EstNomPersonneValide(baseEntite.PrenomResponsable))
            {
                throw new InvalidModelDataException("Le prénom du responsable n'est pas valide");
            }

            if (!ValidateurGenerique.EstRenseigne(baseEntite.QualiteResponsable))
            {
                throw new InvalidModelDataException("Veuillez indiquer la qualité du responsable");
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
                throw new InvalidModelDataException("Veuillez insérer le nom de l'organisme social");
            }

            if (!ValidateurGenerique.EstRenseigne(baseEntite.NumeroOrganismeSociale))
            {
                throw new InvalidModelDataException("Veuillez insérer le numéro d'affiliation de l'organisme social");
            }

            if (!ValidateurGenerique.EstRenseigne(baseEntite.NomServiceImpots))
            {
                throw new InvalidModelDataException("Veuillez insérer le nom du service impôt");
            }

            if (!ValidateurGenerique.EstRenseigne(baseEntite.NumeroAffiliationImpots))
            {
                throw new InvalidModelDataException("Veuillez insérer le numéro d'affiliation du service impôt");
            }

            if (!ValidateurGenerique.EstRenseigne(baseEntite.Adresse))
            {
                throw new InvalidModelDataException("Veuillez indiquer l'adresse");
            }
        }

        public static bool EstValideFormeJuridique(string formeJuridique)
        {
            return formeJuridique == FormeJuridique.EI ||
                formeJuridique == FormeJuridique.EURL ||
                formeJuridique == FormeJuridique.SARL ||
                formeJuridique == FormeJuridique.SAS ||
                formeJuridique == FormeJuridique.SNC ||
                formeJuridique == FormeJuridique.SCOP ||
                formeJuridique == FormeJuridique.SCA;
        }

        //public static readonly string EI = "EI";
        //public static readonly string EURL = "EURL";
        //public static readonly string SA = "SA";
        //public static readonly string SARL = "SARL";
        //public static readonly string SAS = "SAS";
        //public static readonly string SNC = "SNC";
        //public static readonly string SCOP = "SCOP";
        //public static readonly string SCA = "SCA";
    }
}

