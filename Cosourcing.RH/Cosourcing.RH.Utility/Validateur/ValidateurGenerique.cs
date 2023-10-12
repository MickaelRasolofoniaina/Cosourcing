using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace Cosourcing.RH.Utility;

public static class ValidateurGenerique
{
    public static bool EstRenseigne(string champ)
    {
        return !string.IsNullOrEmpty(champ);
    }

    public static bool EstChiffreUniquement(string champ)
    {
        string pattern = "^[0-9]*$";

        return Regex.IsMatch(champ, pattern);
    }

    public static bool EstNChiffreUniquement(string champ, int n)
    {
        string pattern = "^[0-9]{" + n + "}$";

        return Regex.IsMatch(champ, pattern);
    }

    public static bool EstNomPersonneValide(string nom)
    {
        string pattern = "^([^0-9]*)$";

        return Regex.IsMatch(nom, pattern);
    }

    public static bool EstPositif(int nombre)
    {
        return nombre > 0;
    }

    public static bool EstDatePassee(DateTime date)
    {
        return date < DateTime.Now;
    }

    public static bool EstRenseignes(List<String> champs)
    {
        return champs.All(champ => !string.IsNullOrEmpty(champ));
    }
}

