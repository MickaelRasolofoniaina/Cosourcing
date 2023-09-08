namespace Cosourcing.RH.Domain.Entite
{
    public class SocieteModel : BaseEntite
    {
        public string RaisonSociale { get; set; }
        public string NomCommercial { get; set; }
        public string Adresse { get; set; }
        public DateTime DateDeCreation { get; set; }
        public string FormeJuridique { get; set; }
        public string NumeroStatistique { get; set; }
        public string Nif { get; set; }
        public string Activite { get; set; }
        public int NombreEtablissement { get; set; }

        public SocieteModel(
            Guid id,
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
            nomOrganismeSociale,
            numeroOrganismeSociale,
            nomServiceImpots,
            numeroAffiliationImpots,
            commentaire
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