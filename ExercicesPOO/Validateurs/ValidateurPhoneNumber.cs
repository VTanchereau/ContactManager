using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExercicesPOO.Validateurs
{
   class ValidateurPhoneNumber : Validateur
   {

      public override bool Validate(String str)
      {



         String pattern;

         pattern = @"^(0|\[+]33)[1-9][0-9]{8}";
         Regex rgx = new Regex(pattern);
         bool match = rgx.IsMatch(str);

         return match;
      }

      public override void ErrorMessage(Afficheur afficheur)
      {
         afficheur.AfficherErreur("Veuillez renseigner un numéro de téléphone valide.");
      }
   }
}
