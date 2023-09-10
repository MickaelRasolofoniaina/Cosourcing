namespace Cosourcing.RH.Domain.Entite
{
    public static class FormeJuridique
    {
        public static readonly string EI = "EI";
        public static readonly string EURL = "EURL";
        public static readonly string SA = "SA";
        public static readonly string SARL = "SARL";
        public static readonly string SAS = "SAS";
        public static readonly string SNC = "SNC";
        public static readonly string SCOP = "SCOP";
        public static readonly string SCA = "SCA";
    }

    public class SocieteModel : BaseEntite
    {
        public string RaisonSociale { get; set; }
        public string NomCommercial { get; set; }
        public DateTime DateDeCreation { get; set; }
        public string FormeJuridique { get; set; }
        public string NumeroStatistique { get; set; }
        public string Nif { get; set; }
        public string Activite { get; set; }
        public int NombreEtablissement { get; set; }

        public SocieteModel(
            int id,
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
            string iban1,
            string codeBanque2,
            string nomBanque2,
            string adresseBanque2,
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
            RaisonSociale = raisonSociale;
            NomCommercial = nomCommercial;
            Adresse = adresse;
            DateDeCreation = dateDeCreation;
            FormeJuridique = formeJuridique;
            NumeroStatistique = numeroStatistique;
            Nif = nif;
            Activite = activite;
            NombreEtablissement = nombreEtablissement;
        }
    }
}