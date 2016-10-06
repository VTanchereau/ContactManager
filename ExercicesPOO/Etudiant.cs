using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicesPOO
{
   class Etudiant : Contact
   {
      private String cursus;

      public Etudiant(string nom, string prenom, string telephone, string mail) : base(nom, prenom, telephone, mail)
      {
      }

      public String Cursus
      {
         get { return this.cursus; }
         set { this.cursus = value; }
      }

   }
}
