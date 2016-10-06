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

         deserializeEasy();
      }

      public static void deserializeEasy()
      {
         StreamReader reader = new StreamReader("repertoire.txt");
         String line;
         List<Contact> repertoire = new List<Contact>();
         Console.WriteLine();

         while ((line = reader.ReadLine()) != null)
         {
            if (line != "")
            {
               Console.WriteLine(line);
               int indice;
               String nom;
               String prenom;
               String telephone;
               String mail;

               indice = line.IndexOf(';');
               nom = line.Substring(0, indice);
               line = line.Substring(indice + 1);

               indice = line.IndexOf(';');
               prenom = line.Substring(0, indice);
               line = line.Substring(indice + 1);

               indice = line.IndexOf(';');
               telephone = line.Substring(0, indice);
               line = line.Substring(indice + 1);

               mail = line;

               repertoire.Add(new Contact(nom, prenom, telephone, mail));
            }
         }

         foreach (Contact contact in repertoire)
         {
            Console.WriteLine();
            contact.SePresenter();
         }
      }
   }
}
