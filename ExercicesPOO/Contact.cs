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
      protected String nom;
      protected String prenom;
      protected String telephone;
      protected String mail;
      protected DateTime dateDeNaissance;

      public Contact()
      {
         this.prenom = demanderUtilisateur("prenom");
         this.nom = demanderUtilisateur("nom");
         this.telephone = demanderUtilisateur("telephone");
         this.mail = demanderUtilisateur("mail");
      }

      public Contact(String nom, String prenom)
      {
         this.nom = nom;
         this.prenom = prenom;
      }

      public Contact(String nom, String prenom, String telephone, String mail)
      {
         this.nom = nom;
         this.prenom = prenom;
         this.telephone = telephone;
         this.mail = mail;
      }

      public String demanderUtilisateur(String demande)
      {
         Console.WriteLine("Entrez le " + demande + " :");
         return Console.ReadLine();
      }

      public void Afficher()
      {
         String ligne;
         ligne = this.prenom;
         ligne += " " + this.nom;
         ligne += " ; Téléphone : " + this.telephone;
         ligne += " ; Mail : " + this.mail;
         Console.WriteLine(ligne);
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

         enregistrement = this.nom;
         enregistrement += ";" + this.prenom;
         enregistrement += ";" + this.telephone;
         enregistrement += ";" + this.mail;
         sw.WriteLine(enregistrement);
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

      public void SePresenter(bool versionCourte)
      {
         if (versionCourte)
         {
            String ligne;
            Console.WriteLine("---------------------------------------------------------------------");
            ligne = this.prenom;
            ligne += " " + this.nom;
            Console.WriteLine(ligne);
            ligne = "\tTéléphone : " + this.telephone;
            Console.WriteLine(ligne);
            ligne = "\tMail : " + this.mail;
            Console.WriteLine(ligne);
            Console.WriteLine("---------------------------------------------------------------------");
         }
         else
         {
            SePresenter();
         }
         
      }
   }
}