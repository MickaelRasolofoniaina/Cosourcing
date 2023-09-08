﻿
namespace Cosourcing.RH.Domain.Entite
{
	public class BaseEntite : BaseModel
	{
        public string NomResponsable { get; set; }
        public string PrenomResponsable { get; set; }
        public string QualiteResponsable { get; set; }
        public string CodeBanque1 { get; set; }
        public string NomBanque1 { get; set; }
        public string Iban1 { get; set; }
        public string CodeBanque2 { get; set; }
        public string NomBanque2 { get; set; }
        public string Iban2 { get; set; }
        public string NomOrganismeSociale { get; set; }
        public string NumeroOrganismeSociale { get; set; }
        public string NomServiceImpots { get; set; }
        public string NumeroAffiliationImpots { get; set; }
        public string Commentaire { get; set; }

        public BaseEntite(
            Guid id,
            string nomResponsable,
            string prenomResponsable,
            string qualiteResponsable,
            string codeBanque1,
            string nomBanque1,
            string iban1,
            string codeBanque2,
            string nomBanque2,
            string iban2,
            string nomOrganismeSociale,
            string numeroOrganismeSociale,
            string nomServiceImpots,
            string numeroAffiliationImpots,
            string commentaire
        ) : base(id)
		{
            NomResponsable = nomResponsable;
            PrenomResponsable = prenomResponsable;
            QualiteResponsable = qualiteResponsable;
            CodeBanque1 = codeBanque1;
            NomBanque1 = nomBanque1;
            Iban1 = iban1;
            CodeBanque2 = codeBanque2;
            NomBanque2 = nomBanque2;
            Iban2 = iban2;
            NomOrganismeSociale = nomOrganismeSociale;
            NumeroOrganismeSociale = numeroOrganismeSociale;
            NomServiceImpots = nomServiceImpots;
            NumeroAffiliationImpots = numeroAffiliationImpots;
            Commentaire = commentaire;
        }
	}
}
