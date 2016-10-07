using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExercicesPOO
{
   class ValidateurPhoneNumber : Validateur
   {

      public override bool Valider(String str)
      {
         String pattern06;
         String pattern07;

         pattern06 = @"^06[0-9]{8}";
         pattern07 = @"^07[0-9]{8}";
         Regex rgx06 = new Regex(pattern06);
         Regex rgx07 = new Regex(pattern07);
         bool match06 = rgx06.IsMatch(str);
         bool match07 = rgx07.IsMatch(str);

         return match06 || match07;
      }

      public override void ErrorMessage(Afficheur afficheur)
      {
         afficheur.AfficherErreur("Veuillez renseigner un numéro de téléphone valide.");
      }
   }
}
