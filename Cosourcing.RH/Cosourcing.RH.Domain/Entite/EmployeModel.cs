using System.ComponentModel.DataAnnotations.Schema;

namespace Cosourcing.RH.Domain.Entite
{
	public class EmployeModel : BaseModel
	{
        public string Nom { get; set; }
        public string Prenom { get;set; }
        public int Matricule { get; set; }
        public string Genre {get; set; }
        public DateTime DateNaissance {get; set; }
        public string LieuNaissance { get; set; }
        public string PaysNaissance { get; set; }
        public string PaysNationalite { get; set; }
        public string Situation { get; set; }
        public string Adresse { get; set; }
        public string Poste { get; set; }
        public string Categorie { get; set; }
        public string Groupe { get; set; }
        public DateTime DEmbauche { get; set; }
        public DateTime DSortie { get; set; }
        public string MotifSortie { get; set; }
        public float Salaire { get; set; }
        public int Cin { get; set; }
        public string NumCnaps { get; set; }
        public int HeureContractuelle { get; set; }
        public string TypeContrat { get; set; }
        public string ModeReglement { get; set; }
        public int Iban { get; set; }
        public string LieuTravail { get; set; }
        public string Affectation { get; set; }
        public string Commentaire { get; set; }    
        
        [ForeignKey("Employe_IdEtablissement_fkey")]
        public int IdEtablissement { get; set; }
       
        public EmployeModel(
            int id, 
            string nom, 
            string prenom, 
            int matricule, 
            string genre, 
            DateTime dateNaissance, 
            string lieuNaissance, 
            string paysNaissance, 
            string paysNationalite, 
            string situation, 
            string adresse, 
            string poste, 
            string categorie, 
            string groupe, 
            DateTime dEmbauche, 
            DateTime dSortie, 
            string motifSortie, 
            float salaire, 
            int cin, 
            string numCnaps, 
            int heureContractuelle, 
            string typeContrat, 
            string modeReglement, 
            int iban, 
            string lieuTravail, 
            string affectation, 
            string commentaire, 
            int idEtablissement
            ):base(id)
        {
            
            this.Nom = nom;
            this.Prenom = prenom;
            this.Matricule = matricule;
            this.Genre = genre;
            this.DateNaissance = dateNaissance;
            this.LieuNaissance = lieuNaissance;
            this.PaysNaissance = paysNaissance;
            this.PaysNationalite = paysNationalite;
            this.Situation = situation;
            this.Adresse = adresse;
            this.Poste = poste;
            this.Categorie = categorie;
            this.Groupe = groupe;
            this.DEmbauche = dEmbauche;
            this.DSortie = dSortie;
            this.MotifSortie = motifSortie;
            this.Salaire = salaire;
            this.Cin = cin;
            this.NumCnaps = numCnaps;
            this.HeureContractuelle = heureContractuelle;
            this.TypeContrat = typeContrat;
            this.ModeReglement = modeReglement;
            this.Iban = iban;
            this.LieuTravail = lieuTravail;
            this.Affectation = affectation;
            this.Commentaire = commentaire;
            this.IdEtablissement = idEtablissement;
        }

	}
}

