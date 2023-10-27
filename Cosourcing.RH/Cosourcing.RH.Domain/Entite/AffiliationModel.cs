using System.ComponentModel.DataAnnotations.Schema;

namespace Cosourcing.RH.Domain.Entite
{



	public class AffiliationModel : BaseModel
	{

        public DateTime DateAjout { get; set; }           
        
        [ForeignKey("Affiliation_IdEtablissement_fkey")]
        public int IdEtablissement { get; set; }

        [ForeignKey("Affiliation_IdOrganismeSocial_fkey")]
        public int IdOrganismeSocial { get; set; }
       
        public AffiliationModel(
            int id,
            DateTime dateAjout, 
           
            int idEtablissement,
            int idOrganismeSocial
            ):base(id)
        {
            
            this.DateAjout = dateAjout;            
            this.IdEtablissement = idEtablissement;
            this.IdOrganismeSocial = idOrganismeSocial;
        }

	}
}

