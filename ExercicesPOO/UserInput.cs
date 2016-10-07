using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExercicesPOO
{
   class UserInput
   {
      private Afficheur afficheur;

      public UserInput(Afficheur afficheur)
      {
         this.afficheur = afficheur;
      }

      public String getInput(String message, Validateur valider)
      {
         String input;
         if (message != "")
         {
            this.afficheur.AfficherDemande(message);
         }

         while (true)
         {
            input = Console.ReadLine();
            if (valider.isEmpty(input))
            {
               valider.EmptyErrorMessage(this.afficheur);
            }
            else
            {
               if (valider.Valider(input))
               {
                  return input;
               }
               else
               {
                  valider.ErrorMessage(this.afficheur);
               }
            }
            
         }
      }
   }
}
