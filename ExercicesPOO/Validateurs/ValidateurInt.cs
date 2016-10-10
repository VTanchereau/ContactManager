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
      public override bool Validate(String str)
      {
         try
         {
            int.Parse(str);
         }
         catch (FormatException e)
         {
            throw new ValidateurException(Constantes.ERREUR_FORMAT_ENTIER, e);
         }
         catch (OverflowException e)
         {
            throw new ValidateurException(Constantes.ERREUR_TAILLE_ENTIER, e);
         }
         catch (Exception e)
         {
            throw new ValidateurException(Constantes.ERREUR_GENERIQUE, e);
         }
         return true;
      }

      public override void ErrorMessage(Afficheur afficheur)
      {
         afficheur.AfficherErreur("Veuillez renseigner un nombre entier.");
      }
   }
}
