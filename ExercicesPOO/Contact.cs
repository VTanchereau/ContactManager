using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExercicesPOO
{
   class Contact
   {
      protected String nom;
      protected String prenom;
      protected String telephone;
      protected String mail;

      public Contact(String nom, String prenom, String telephone, String mail)
      {
         this.nom = nom;
         this.prenom = prenom;
         this.telephone = telephone;
         this.mail = mail;
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

      public static bool isChamp(String str)
      {
         str = str.ToUpper();
         bool prenomBool = str.Equals("PRENOM");
         bool nomBool = str.Equals("NOM");
         bool mailBool = str.Equals("MAIL");
         bool telBool = str.Equals("TELEPHONE");

         return prenomBool || nomBool || mailBool || telBool;
      }

      public bool RechercherParChamp(String nomChamp, String motCle)
      {
         String pattern;
         Regex rgx;
         bool match;

         pattern = @"" + motCle.ToUpper();
         rgx = new Regex(pattern);
         match = false;
         nomChamp = nomChamp.ToUpper();

         if (nomChamp == "PRENOM")
         {
            match = (rgx.IsMatch(this.prenom.ToUpper()));
         }
         if (nomChamp == "NOM")
         {
            match = (rgx.IsMatch(this.nom.ToUpper()));
         }
         if (nomChamp == "MAIL")
         {
            match = (rgx.IsMatch(this.mail.ToUpper()));
         }
         if (nomChamp == "TELEPHONE")
         {
            match = (rgx.IsMatch(this.telephone.ToUpper()));
         }

         return match;
      }

      public String ExtractTXT()
      {
         String ligne;
         ligne = this.prenom;
         ligne = ligne.PadRight(50, ' ');
         ligne += this.nom;
         ligne = ligne.PadRight(100, ' ');
         ligne += this.telephone;
         ligne = ligne.PadRight(115, ' ');
         ligne += this.mail;
         ligne = ligne.PadRight(165, ' ');
         return ligne;
      }

      public String ExtractCSV()
      {
         String ligne;
         ligne = this.prenom;
         ligne += ";" + this.nom;
         ligne += ";" + this.telephone;
         ligne += ";" + this.mail;
         return ligne;
      }

      public String Affichage()
      {
         String ligne;
         ligne = this.prenom + " " + this.nom;
         ligne += "\n\tTéléphone : " + this.telephone;
         ligne += "\n\tMail : " + this.mail;
         return ligne;
      }
   }
}