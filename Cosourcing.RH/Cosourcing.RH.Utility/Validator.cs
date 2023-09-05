namespace Cosourcing.RH.Utility;
using System.Text.RegularExpressions;


public static class Validator
{
    // Example
    public static Boolean isEmailValid(string email)
    {
        return false;
    }

    public static bool IsValidNomCommercial(string NomCommercial)
    {
       
        string pattern = "^[a-zA-Z ]+$";
        return Regex.IsMatch(NomCommercial, pattern);
    }

   


}

