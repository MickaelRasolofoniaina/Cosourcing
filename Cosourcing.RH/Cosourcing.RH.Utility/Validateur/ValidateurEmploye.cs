using System.Net.Sockets;
using Cosourcing.RH.Domain.Entite;
using Cosourcing.RH.Domain.Exception;
using System.Globalization;

namespace Cosourcing.RH.Utility.Validateur
{
	public static class ValidateurEmploye
	{
        public static bool ValiderEmploye(EmployeModel employeModel)
        {
            Dictionary<string, string> champsAValider = new Dictionary<string, string>
            {
                { "Nom", employeModel.Nom },
                { "Prenom", employeModel.Prenom },
                { "Genre", employeModel.Genre },
                { "Adresse", employeModel.Adresse },
                { "Poste", employeModel.Poste },
                { "Categorie", employeModel.Categorie },
                { "Groupe", employeModel.Groupe },
                { "Cin", employeModel.Cin },
                { "TypeContrat", employeModel.TypeContrat },
                { "ModeReglement", employeModel.ModeReglement },
                { "LieuTravail", employeModel.LieuTravail },
            };

            List<string> champsNonRenseignes = new List<string>();

            foreach (var kvp in champsAValider)
            {
                if (string.IsNullOrEmpty(kvp.Value))
                {
                    champsNonRenseignes.Add(kvp.Key);
                }
            }

            if (champsNonRenseignes.Count > 0)
            {
                string champsManquants = string.Join(", ", champsNonRenseignes);
                throw new InvalidModelDataException($"Les champs suivants ne sont pas renseignés : {champsManquants}");
            }

            return true;
        }



        
        public static bool EstValideSituation(string situation)
        {
            if (Enum.TryParse<Situation>(situation, out Situation situationEnum))
            {
                
                switch (situationEnum)
                {
                    case Situation.CELIBATAIRE:
                    case Situation.MARIE:
                    case Situation.DIVORCE:
                    case Situation.NONCONNUE:
                        return true;
                    default:
                        return false;
                }
            }
            return false; 
        }
        public static bool EstValideMotifSortie(string motifSortie)
        {
            if (Enum.TryParse<MotifSortie>(motifSortie, out MotifSortie motifSortieEnum))
            {
                
                switch (motifSortieEnum)
                {
                    case MotifSortie.DEMISSION:
                    case MotifSortie.LICENCIEMENT:
                    case MotifSortie.FIN_ESSAI_EMPLOYEUR:
                    case MotifSortie.FIN_ESSAI_SALARIE:
                    case MotifSortie.FIN_CDD_EMPLOYEUR:
                    case MotifSortie.FIN_CDD_SALARIE:
                        return true;
                    default:
                        return false;
                }
            }
            return false; 
        }

        public static bool EstValideTypeContrat(string typeContrat)
        {
            if (Enum.TryParse<TypeContrat>(typeContrat, out TypeContrat typeContratEnum))
            {
                
                switch (typeContratEnum)
                {
                    case TypeContrat.CDD:
                    case TypeContrat.CDI:
                        return true;
                    default:
                        return false;
                }
            }
            return false; 
        }

        public static bool EstValideModeReglement(string modeReglement)
        {
            if (Enum.TryParse<ModeReglement>(modeReglement, out ModeReglement modeReglementEnum))
            {
                
                switch (modeReglementEnum)
                {
                    case ModeReglement.VIREMENT:
                    case ModeReglement.CHEQUE:
                        return true;
                    default:
                        return false;
                }
            }
            return false; 
        }


        public static bool EstValideGenre(string genre)
        {
            if (Enum.TryParse<Genre>(genre, out Genre genreEnum))
            {
                
                switch (genreEnum)
                {
                    case Genre.HOMME:
                    case Genre.FEMME:
                    case Genre.AUTRE:
                        return true;
                    default:
                        return false;
                }
            }
            return false; 
        }

        public static bool EstValidePoste(string poste)
        {
            if (Enum.TryParse<Poste>(poste, out Poste posteEnum))
            {
                
                switch (posteEnum)
                {
                    case Poste.DEVELOPPEUR:
                    case Poste.DIRECTEUR:
                    case Poste.AGENT:
                        return true;
                    default:
                        return false;
                }
            }
            return false; 
        }

        public static bool EstValideCategorie(string categorie)
        {
            if (Enum.TryParse<Categorie>(categorie, out Categorie categorieEnum))
            {
                
                switch (categorieEnum)
                {
                    case Categorie.CATEGORIE1:
                    case Categorie.CATEGORIE2:
                        return true;
                    default:
                        return false;
                }
            }
            return false; 
        }

        public static bool EstValideGroupe(string groupe)
        {
            if (Enum.TryParse<Groupe>(groupe, out Groupe groupeEnum))
            {
                
                switch (groupeEnum)
                {
                    case Groupe.GROUPE1:
                    case Groupe.GROUPE2:
                        return true;
                    default:
                        return false;
                }
            }
            return false; 
        }

        public static bool EstValidePays(string codePays){
            try{
                RegionInfo region = new RegionInfo(codePays);
                return true;                
            }
            catch{
                return false;
            }
        }





    }
}

