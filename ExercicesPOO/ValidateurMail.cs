using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExercicesPOO
{
   class ValidateurMail : Validateur
   {

      public override bool Validate(String str)
      {
         String patternNet;
         String patternCom;
         String patternFr;

         patternCom = @"[a-z]+[._-]?[a-z]*@[a-z]+.com";
         patternNet = @"[a-z]+[._-]?[a-z]*@[a-z]+.net";
         patternFr = @"[a-z]+[._-]?[a-z]*@[a-z]+.fr";

         Regex rgxCom = new Regex(patternCom);
         Regex rgxFr = new Regex(patternFr);
         Regex rgxNet = new Regex(patternNet);
         bool matchCom = rgxCom.IsMatch(str);
         bool matchFr = rgxFr.IsMatch(str);
         bool matchNet = rgxNet.IsMatch(str);

         return matchCom || matchFr || matchNet;
      }

      public override void ErrorMessage(Afficheur afficheur)
      {
         afficheur.AfficherErreur("Veuillez renseigner un mail valide.");
      }
   }
}
