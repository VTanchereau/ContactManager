using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContactManager
{
   class ValidateurWords : Validateur
   {

      public override bool Validate(String str)
      {
         String pattern;
         pattern = @"[A-Z]?[a-z]+";
         Regex rgx = new Regex(pattern);
         Match ma = rgx.Match(str);
         if (ma.Value.Length == str.Length)
         {
            return true;
         }
         return false;
      }

      public override void ErrorMessage(Afficheur afficheur)
      {
         afficheur.AfficherErreur("Veuillez renseigner un mot sans caractères spéciaux ni espaces.");
      }
   }
}
