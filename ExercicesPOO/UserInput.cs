using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContactManager
{
   class UserInput
   {
      private Afficheur afficheur;

      public UserInput(Afficheur afficheur)
      {
         this.afficheur = afficheur;
      }

      public String getInput(String message, Validateur validateur)
      {
         String input;
         if (message != "")
         {
            this.afficheur.AfficherDemande(message);
         }

         while (true)
         {
            input = Console.ReadLine();
            if (validateur.IsEmpty(input))
            {
               validateur.EmptyErrorMessage(this.afficheur);
            }
            else
            {
               if (validateur.Validate(input))
               {
                  return input;
               }
               else
               {
                  validateur.ErrorMessage(this.afficheur);
               }
            }
            
         }
      }
   }
}
