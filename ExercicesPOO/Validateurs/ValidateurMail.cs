using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExercicesPOO.Validateurs
{
   class ValidateurMail : Validateur
   {

      public override bool Validate(String str)
      {
         String[] splitage;
         splitage = str.Split('@');

         if (splitage.Length != 2)
         {
            return false;
         }

         if ((splitage[0].Length == 0) || (splitage[1].Length == 0))
         {
            return false;
         }

         Program.DEBUG(splitage[0]);
         Program.DEBUG(splitage[1]);

         splitage = splitage[1].Split('.');
         Program.DEBUG(splitage[0]);
         Program.DEBUG(splitage[1]);
         if (splitage.Length != 2)
         {
            return false;
         }
         if ((splitage[0].Length == 0) || (splitage[1].Length == 0))
         {
            return false;
         }

         return true;
      }

      public override void ErrorMessage(Afficheur afficheur)
      {
         afficheur.AfficherErreur("Veuillez renseigner un mail valide.");
      }
   }
}
