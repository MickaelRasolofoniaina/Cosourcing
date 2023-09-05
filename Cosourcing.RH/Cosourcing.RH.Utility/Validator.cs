using System.Text.RegularExpressions;

namespace Cosourcing.RH.Utility;

public static class Validator
{
    public static bool EstRenseigne(string champ)
    {
        return !String.IsNullOrEmpty(champ);
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
}

