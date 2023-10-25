using System.ComponentModel.DataAnnotations.Schema;

namespace Cosourcing.RH.Domain.Entite
{
    public class OrganismeSocialModel : BaseModel
	{
        public string Nom {get; set; }
        public string Adresse { get; set; } 
        public decimal BaseCotisationSocialeEmployeur { get; set; } 
        public decimal BaseCotisationSocialeSalarie { get; set; } 
        public decimal BaseTauxCotisationSocialeEmployeur { get; set; } 
        public decimal BaseTauxCotisationSocialeSalarie { get; set; }
        
        [ForeignKey("OrganismeSocial_IdEtablissement_fkey")]
        public int IdEtablissement { get; set; }
    
        public OrganismeSocialModel(
            int id, 
            string nom,
            string  adresse,
            decimal baseCotisationSocialeEmployeur ,
            decimal baseCotisationSocialeSalarie,
            decimal baseTauxCotisationSocialeEmployeur,
            decimal baseTauxCotisationSocialeSalarie,
            int idEtablissement
            ):base(id)
        {
            
            this.Nom = nom;           
            this.Adresse = adresse;
            this.BaseCotisationSocialeEmployeur = baseCotisationSocialeEmployeur;
            this.BaseCotisationSocialeSalarie = baseCotisationSocialeSalarie;
            this.BaseTauxCotisationSocialeEmployeur = baseTauxCotisationSocialeEmployeur;
            this.BaseTauxCotisationSocialeSalarie = baseTauxCotisationSocialeSalarie;           
            this.IdEtablissement = idEtablissement;
        }

	}
}

