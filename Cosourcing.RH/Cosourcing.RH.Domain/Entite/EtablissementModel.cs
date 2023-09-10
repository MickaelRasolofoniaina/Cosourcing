namespace Cosourcing.RH.Domain.Entite
{
	public class EtablissementModel : BaseEntite
	{
		
        public string Nom { get; set; }
        public string Activite { get; set; }
        public int IdSociete { get; set; }

        public EtablissementModel(
            int id,
		    string nom,
            string adresse,
            string activite,
            string nomResponsable,
            string prenomResponsable,
            string qualiteResponsable,
            string codeBanque1,
            string nomBanque1,
            string adresseBanque1,
            string iban1,
            string codeBanque2,
            string nomBanque2,
            string adresseBanque2,
            string iban2,
            string nomOrganismeSociale,
            string numeroOrganismeSociale,
            string nomServiceImpots,
            string numeroAffiliationImpots,
            string commentaire,
            int idSociete

        ) : base(
            id,
            nomResponsable,
            prenomResponsable,
            qualiteResponsable,
            codeBanque1,
            nomBanque1,
            adresseBanque1,
            iban1,
            codeBanque2,
            nomBanque2,
            adresseBanque2,
            iban2,
            nomOrganismeSociale,
            numeroOrganismeSociale,
            nomServiceImpots,
            numeroAffiliationImpots,
            commentaire,
            adresse
        )
		{
            Nom = nom;
            Adresse = adresse;
            Activite = activite;
            IdSociete = idSociete;
		}
	}
}

