using System.Net.Sockets;
using Cosourcing.RH.Domain.Entite;
using Cosourcing.RH.Domain.Exception;

namespace Cosourcing.RH.Utility.Validateur
{
	public static class ValidateurEmploye
	{
		public static bool ValiderEmploye(EmployeModel employeModel)
		{
            List<string> champsAValider = new List<string>
                    {
                        employeModel.Nom,
                        employeModel.Prenom,
                        employeModel.Genre,
                        employeModel.Adresse,
                        employeModel.Poste,
                        employeModel.Categorie,
                        employeModel.Groupe,
                        employeModel.Cin,
                        employeModel.TypeContrat,
                        employeModel.ModeReglement,
                        employeModel.LieuTravail,
                    };

            if (!ValidateurGenerique.EstRenseignes(champsAValider))
            {
                    throw new InvalidModelDataException("Veuillez indiquer les champs obligatoires.");
            }
            return true;
           
        }

        public static bool EstContratValide(string typeContrat)
        {
            return typeContrat == TypeContrat.CDD;
        }


    }
}

