using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

#pragma warning disable 168

namespace ExercicesPOO
{
   class UserInput
   {
      private Afficheur afficheur;
      private Menu menu;

      public UserInput(Afficheur afficheur, Menu menu)
      {
         this.afficheur = afficheur;
         this.menu = menu;
      }

      public String getInput(String message, Validateurs.Validateur validateur)
      {
         String input;
         if (message != "")
         {
            this.afficheur.AfficherDemande(message);
         }

         while (true)
         {
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
               validateur.EmptyErrorMessage(this.afficheur);
            }
            else
            {
               try
               {
                  validateur.Validate(input);
                  break;
               }
               catch(Exceptions.ValidateurException e)
               {
                  this.afficheur.AfficherErreur(e.Message);
               }
            }
         }
         return input;
      }
   }
}
