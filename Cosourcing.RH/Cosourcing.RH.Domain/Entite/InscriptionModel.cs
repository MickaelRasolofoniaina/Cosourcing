using System.ComponentModel.DataAnnotations.Schema;

namespace Cosourcing.RH.Domain.Entite
{



	public class InscriptionModel : BaseModel
	{

        public DateTime DateAjout { get; set; }           
        
        [ForeignKey("Inscription_IdEtablissement_fkey")]
        public int IdEtablissement { get; set; }

        [ForeignKey("Inscription_IdServiceImpot_fkey")]
        public int IdServiceImpot { get; set; }
       
        public InscriptionModel(
            int id,
            DateTime dateAjout, 
           
            int idEtablissement,
            int idServiceImpot
            ):base(id)
        {
            
            this.DateAjout = dateAjout;            
            this.IdEtablissement = idEtablissement;
            this.IdServiceImpot = idServiceImpot;
        }

	}
}

