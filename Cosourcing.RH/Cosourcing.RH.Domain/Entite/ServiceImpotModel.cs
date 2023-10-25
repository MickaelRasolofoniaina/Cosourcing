using System.ComponentModel.DataAnnotations.Schema;

namespace Cosourcing.RH.Domain.Entite
{
    public class ServiceImpotModel : BaseModel
	{
        public string Nom {get; set; }
        public string Adresse { get; set; }
        public string NomImpotObligatoire {get; set;} 
        public decimal BaseCotisationImposableEmployeur { get; set; } 
        public decimal BaseCotisationImposableSalarie { get; set; } 
        public decimal BaseTauxImpotEmployeur { get; set; } 
        public decimal BaseTauxImpotSalarie { get; set; }
        public decimal ReductionImpot {get; set; }
        
        [ForeignKey("ServiceImpot_IdEtablissement_fkey")]
        public int IdEtablissement { get; set; }
    
        public ServiceImpotModel(
            int id, 
            string nom,
            string nomImpotObligatoire,
            string  adresse,
            decimal baseCotisationImposableEmployeur ,
            decimal baseCotisationImposableSalarie,
            decimal baseTauxImpotEmployeur,
            decimal baseTauxImpotSalarie,
            decimal reductionImpot,
            int idEtablissement
            ):base(id)
        {
            
            this.Nom = nom;           
            this.Adresse = adresse;
            this.NomImpotObligatoire = nomImpotObligatoire;
            this.BaseCotisationImposableEmployeur = baseCotisationImposableEmployeur;
            this.BaseCotisationImposableSalarie = baseCotisationImposableSalarie;
            this.BaseTauxImpotEmployeur = baseTauxImpotEmployeur;
            this.BaseTauxImpotSalarie = baseTauxImpotSalarie;           
            this.IdEtablissement = idEtablissement;
            this.ReductionImpot = reductionImpot;
        }

	}
}

