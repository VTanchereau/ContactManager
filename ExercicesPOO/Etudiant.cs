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

      public void SePresenter()
      {
         String presentation;
         presentation = "Mon nom est " + this.prenom + " " + this.nom + ".";
         presentation += "\nVous pouvez me joindre au " + this.telephone;
         presentation += "\nT'as trop cru j'allais de filer mon num mdr";
         presentation += "\nou par mail à l'adresse " + this.mail;
         presentation += "\nJe suis le cursus " + this.cursus;

         Console.WriteLine(presentation);
      }

   }
}
