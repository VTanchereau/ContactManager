using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicesPOO
{
   class Program
   {
      static void Main(string[] args)
      {
         Contact jacques = new Contact("Chirac", "Jacques", "06********", "jacquouille_du_44@hotmail.com");
         Contact lionel = new Contact("Jospin", "Lionel", "07********", "lion_king@laposte.net");
         jacques.SePresenter();
         Console.WriteLine();
         lionel.SePresenter();

         lionel.Telephone = "0708091011";
         Console.WriteLine();
         lionel.SePresenter();

         String fileName = "repertoire.txt";
         StreamWriter sw = File.CreateText(fileName);
         sw.Close();

         lionel.Enregistrer(fileName);
         jacques.Enregistrer(fileName);

         StreamReader reader = new StreamReader("repertoire.txt");
         String line;
         List<Contact> repertoire = new List<Contact>();
         Console.WriteLine();

         String champ;
         String value = "";
         String nom = "";
         String prenom = "";
         String telephone = "";
         String mail = "";

         while ((line = reader.ReadLine()) != null)
         {
            
            int index;
            if (line != "")
            {
               index = line.IndexOf('=');
               champ = line.Substring(0, index);
               value = line.Substring(index + 1);

               if (champ.Equals("nom"))
               {
                  nom = value;
               }
               if (champ.Equals("prenom"))
               {
                  prenom = value;
               }
               if (champ.Equals("telephone"))
               {
                  telephone = value;
               }
               if (champ.Equals("mail"))
               {
                  mail = value;
               }
            }
            else
            {
               repertoire.Add(new Contact(nom, prenom, telephone, mail));
            }
         }
         foreach (Contact contact in repertoire){
            Console.WriteLine();
            contact.SePresenter();
         }
      }
   }
}
