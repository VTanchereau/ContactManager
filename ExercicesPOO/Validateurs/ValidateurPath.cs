using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExercicesPOO.Validateurs
{
   class ValidateurPath : Validateur
   {
      public override bool Validate(String str)
      {
         System.IO.FileInfo fi = null;
         try
         {
            fi = new System.IO.FileInfo(str);
         }
         catch (Exception)
         {
            Console.WriteLine("Désolé, j'ai planté");
         }
         //catch (System.IO.PathTooLongException) { }
         //catch (NotSupportedException) { }
         if (ReferenceEquals(fi, null))
         {
            return false;
         }
         else
         {
            return true;
         }
      }

      public override void ErrorMessage(Afficheur afficheur)
      {
         afficheur.AfficherErreur("Le chemin renseigné n'est pas valide.");
      }
   }
}
