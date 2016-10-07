using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
   class ValidateurChamp : Validateur
   {
      public override bool Validate(String str)
      {
         return Contact.isChamp(str);
      }

      public override void ErrorMessage(Afficheur afficheur)
      {
         afficheur.AfficherErreur("Veuillez renseigner un champ valide.");
      }
   }
}
