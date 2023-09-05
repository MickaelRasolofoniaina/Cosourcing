namespace Cosourcing.RH.Domain.Entite
{
	public class EtablissementModel : BaseEntite
	{
		
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Activite { get; set; }

        public EtablissementModel(
            Guid id,
		    string nom,
            string adresse,
            string activite,
            string nomResponsable,
            string prenomResponsable,
            string qualiteResponsable,
            string codeBanque1,
            string nomBanque1,
            string iban1,
            string codeBanque2,
            string nomBanque2,
            string iban2,
            int nombreEtablissement,
            string nomOrganismeSociale,
            string numeroOrganismeSociale,
            string nomServiceImpots,
            string numeroAffiliationImpots,
            string commentaire

        ) : base(
            id,
            nomResponsable,
            prenomResponsable,
            qualiteResponsable,
            codeBanque1,
            nomBanque1,
            iban1,
            codeBanque2,
            nomBanque2,
            iban2,
            nombreEtablissement,
            nomOrganismeSociale,
            numeroOrganismeSociale,
            nomServiceImpots,
            numeroAffiliationImpots,
            commentaire
        )
		{
            Nom = nom;
            Adresse = adresse;
            Activite = activite;
		}
	}
}

