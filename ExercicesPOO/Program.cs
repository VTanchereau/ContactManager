using System;
using System.Collections.Generic;
using System.IO;

namespace ExercicesPOO
{
   class Program
   {
      static void Main(string[] args)
      {
         Menu menu = new Menu();

         while (menu.Continuer)
         {
            menu.Afficher();
            menu.ExecuterChoix(menu.RecupererChoix());
         }
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
