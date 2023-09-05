namespace Cosourcing.RH.Domain.Etablissement
{
	public class EtablissementModel : BaseModel
	{
		
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Activite { get; set; }
        public string NomResponsable { get; set; }
        public string PrenomResponsable { get; set; }
        public string QualiteResponsable { get; set; }
        public string CodeBanque1 { get; set; }
        public string NomBanque1 { get; set; }
        public string Iban1 { get; set; }
        public string CodeBanque2 { get; set; }
        public string NomBanque2 { get; set; }
        public string Iban2 { get; set; }
        public int NombreEtablissement { get; set; }
        public string NomOrganismeSociale { get; set; }
        public string NumeroOrganismeSociale { get; set; }
        public string NomServiceImpots { get; set; }
        public string NumeroAffiliationImpots { get; set; }
        public string Commentaire { get; set; }

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
		) : base(id)
		{
            Nom = nom;
            Adresse = adresse;
            Activite = activite;
            NomResponsable = nomResponsable;
            PrenomResponsable = prenomResponsable;
            QualiteResponsable = qualiteResponsable;
            CodeBanque1 = codeBanque1;
            NomBanque1 = nomBanque1;
            Iban1 = iban1;
            CodeBanque2 = codeBanque2;
            NomBanque2 = nomBanque2;
            Iban2 = iban2;
            NombreEtablissement = nombreEtablissement;
            NomOrganismeSociale = nomOrganismeSociale;
            NumeroOrganismeSociale = numeroOrganismeSociale;
            NomServiceImpots = nomServiceImpots;
            NumeroAffiliationImpots = numeroAffiliationImpots;
            Commentaire = commentaire;
		}
	}
}

