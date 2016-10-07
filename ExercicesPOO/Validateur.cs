using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
   abstract class Validateur
   {
      public abstract bool Validate(String str);

      public abstract void ErrorMessage(Afficheur afficheur);

      public bool IsEmpty(String str)
      {
         return (str == "");
      }

      public void EmptyErrorMessage(Afficheur affichage)
      {
         affichage.AfficherErreur("Le message entré est vide.");
      }
   }
}
