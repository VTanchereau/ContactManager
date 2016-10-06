using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicesPOO
{
   class Enseignant : Contact
   {
      private String matiere;

      public Enseignant(string nom, string prenom, string telephone, string mail) : base(nom, prenom, telephone, mail)
      {
      }

      public String Matiere
      {
         get { return this.matiere; }
         set { this.matiere = value; }
      }
   }
}
