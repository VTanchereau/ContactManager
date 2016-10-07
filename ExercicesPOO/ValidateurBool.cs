using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContactManager
{
   class ValidateurBool : Validateur
   {
      public override bool Validate(String str)
      {
         bool oui;
         bool non;

         String pattern;
         pattern = @"[Oo][Uu][Ii]";
         Regex rgx = new Regex(pattern);
         Match ma = rgx.Match(str);
         if (ma.Value.Length == str.Length)
         {
            oui = true;
         }
         else
         {
            oui = false;
         }

         pattern = @"[Nn][Oo][Nn]";
         rgx = new Regex(pattern);
         ma = rgx.Match(str);
         if (ma.Value.Length == str.Length)
         {
            non = true;
         }
         else
         {
            non = false;
         }

         return oui || non;
      }

      public override void ErrorMessage(Afficheur afficheur)
      {
         afficheur.AfficherErreur("Veuillez entrer oui ou non.");
      }
   }
}
