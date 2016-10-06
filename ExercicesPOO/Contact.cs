using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicesPOO
{
   class Contact
   {
      private String nom;
      private String prenom;
      private String telephone;
      private String mail;
      private DateTime dateDeNaissance;



      public Contact(String nom, String prenom, String telephone, String mail)
      {
         this.nom = nom;
         this.prenom = prenom;
         this.telephone = telephone;
         this.mail = mail;
      }

      public String demanderUtilisateur(String demande)
      {
         Console.WriteLine("Entrez votre " + demande + " :");
         return Console.ReadLine();
      }

      public String Nom
      {
         get { return this.nom; }
      }

      public String Prenom
      {
         get { return this.prenom; }
      }

      public String Telephone
      {
         get { return this.telephone; }
         set { this.telephone = value; }
      }

      public String Mail
      {
         get { return this.mail; }
         set { this.mail = value; }
      }

      public void Enregistrer(String fichier)
      {
         StreamWriter sw = new StreamWriter(fichier, true);
         String enregistrement;

         enregistrement = "nom=" + this.nom;
         sw.WriteLine(enregistrement);
         enregistrement = "prenom=" + this.prenom;
         sw.WriteLine(enregistrement);
         enregistrement = "telephone=" + this.telephone;
         sw.WriteLine(enregistrement);
         enregistrement = "mail=" + this.mail;
         sw.WriteLine(enregistrement);
         sw.WriteLine();
         sw.Close();
      }


      public void SePresenter()
      {
         String presentation;
         presentation = "Mon nom est " + this.prenom + " " + this.nom + ".";
         presentation += "\nVous pouvez me joindre au " + this.telephone;
         presentation += "\nT'as trop cru j'allais de filer mon num mdr";
         presentation += "\nou par mail à l'adresse " + this.mail;

         Console.WriteLine(presentation);
      }
   }
}