using System.Net.Sockets;
using Cosourcing.RH.Domain.Entite;
using Cosourcing.RH.Domain.Exception;
using System.Globalization;
using System;
using System.Collections.Generic;

namespace Cosourcing.RH.Utility.Validateur
{
	public static class ValidateurServiceImpot
	{
        public static bool ValiderServiceImpot(ServiceImpotModel serviceImpotModel)
        {
            Dictionary<string, string> champsAValider = new Dictionary<string, string>
            {
                { "Nom", serviceImpotModel.Nom },
                { "Adresse", serviceImpotModel.Adresse },
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



        
        public static bool EstPositif(decimal valeur)
        {
             return valeur >= 0;
        }





    }
}

