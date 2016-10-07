using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExercicesPOO
{
   class ValidateurInt : Validateur
   {
      public override bool Valider(String str)
      {
         String pattern;
         pattern = @"[0-9]+";
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
         afficheur.AfficherErreur("Veuillez renseigner un nombre entier.");
      }
   }
}
