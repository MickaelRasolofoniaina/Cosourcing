using System;

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
    public int CodeBanque1 { get; set; }
    public string NomBanque1 { get; set; }
    public int Iban1 { get; set; }
    public int CodeBanque2 { get; set; }
    public string NomBanque2 { get; set; }
    public int Iban2 { get; set; }
    public int NbEtab { get; set; }
    public string OrganismeSociale { get; set; }
    public string NumOrganismeSociale { get; set; }
    public string NomImpots { get; set; }
    public int NumImpots { get; set; }
    public string Commentaire { get; set; }

        public EtablissementModel(
        Guid id,
        bool deleted,
		string nom,
        string adresse,
        string activite,
        string nomResponsable,
        string prenomResponsable,
        string qualiteResponsable,
        int codeBanque1,
        string nomBanque1,
        int iban1,
        int codeBanque2,
        string nomBanque2,
        int iban2,
        int nbEtab,
        string organismeSociale,
        string numOrganismeSociale,
        string nomImpots,
        int numImpots,
        string commentaire
		) : base(id, deleted)
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
        NbEtab = nbEtab;
        OrganismeSociale = organismeSociale;
        NumOrganismeSociale = numOrganismeSociale;
        NomImpots = nomImpots;
        NumImpots = numImpots;
        Commentaire = commentaire;
		}
	}
}

