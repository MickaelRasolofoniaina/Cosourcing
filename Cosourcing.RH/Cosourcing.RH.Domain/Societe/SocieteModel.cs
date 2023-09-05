namespace Cosourcing.RH.Domain.Societe
{
    public class SocieteModel : BaseModel
    {
        public string RaisonSociale { get; set; }
        public string NomCommercial { get; set; }
        public string Adresse { get; set; }
        public DateTime DateDeCreation { get; set; }
        public string FormeJuridique { get; set; }
        public string NumeroStatistique { get; set; }
        public string Nif { get; set; }
        public string Activite { get; set; }
        public string NomResponsable { get; set; }
        public string PrenomResponsable { get; set; }
        public string QualiteResponsable { get; set; }
        public string CodeBanque1 { get; set; }
        public string NomBanque1 { get; set; }
        public string AdresseBanque1 { get; set; }
        public string IbanBanque1 { get; set; }
        public string CodeBanque2 { get; set; }
        public string NomBanque2 { get; set; }
        public string AdresseBanque2 { get; set; }
        public string IbanBanque2 { get; set; }
        public int NombreEtablissement { get; set; }
        public string NomOrganismeSocial { get; set; }
        public string NumeroAffiliationOrganismeSocial { get; set; }
        public string NomServiceImpot { get; set; }
        public string NumeroAffiliation { get; set; }
        public string Commentaire { get; set; }

        public SocieteModel(
            Guid id,
            bool deleted,
            string raisonSociale,
            string nomCommercial,
            string adresse,
            DateTime dateDeCreation,
            string formeJuridique,
            string numeroStatistique,
            string nif,
            string activite,
            string nomResponsable,
            string prenomResponsable,
            string qualiteResponsable,
            string codeBanque1,
            string nomBanque1,
            string adresseBanque1,
            string ibanBanque1,
            string codeBanque2,
            string nomBanque2,
            string adresseBanque2,
            string ibanBanque2,
            int nombreEtablissement,
            string nomOrganismeSocial,
            string numeroAffiliationOrganismeSocial,
            string nomServiceImpot,
            string numeroAffiliation,
            string commentaire
        ) : base(id, deleted)
        {
            RaisonSociale = raisonSociale;
            NomCommercial = nomCommercial;
            Adresse = adresse;
            DateDeCreation = dateDeCreation;
            FormeJuridique = formeJuridique;
            NumeroStatistique = numeroStatistique;
            Nif = nif;
            Activite = activite;
            NomResponsable = nomResponsable;
            PrenomResponsable = prenomResponsable;
            QualiteResponsable = qualiteResponsable;
            CodeBanque1 = codeBanque1;
            NomBanque1 = nomBanque1;
            AdresseBanque1 = adresseBanque1;
            IbanBanque1 = ibanBanque1;
            CodeBanque2 = codeBanque2;
            NomBanque2 = nomBanque2;
            AdresseBanque2 = adresseBanque2;
            IbanBanque2 = ibanBanque2;
            NombreEtablissement = nombreEtablissement;
            NomOrganismeSocial = nomOrganismeSocial;
            NumeroAffiliationOrganismeSocial = numeroAffiliationOrganismeSocial;
            NomServiceImpot = nomServiceImpot;
            NumeroAffiliation = numeroAffiliation;
            Commentaire = commentaire;
        }
    }
}