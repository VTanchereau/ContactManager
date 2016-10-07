using System;
using System.Collections.Generic;

namespace ExercicesPOO
{
   class Repertoire
   {
      private List<Contact> contenu;

      public Repertoire(List<Contact> entrees)
      {
         this.contenu = entrees;
      }

      public List<Contact> Contenu
      {
         get { return this.contenu; }
      }

      public void Add(Contact contact)
      {
         this.contenu.Add(contact);
      }

      public List<Contact> Rechercher(String motCle)
      {
         bool match;
         List<Contact> searchResult;

         searchResult = new List<Contact>();

         foreach (Contact contact in this.contenu)
         {
            Program.DEBUG(motCle);
            match = contact.RechercherParChamp("nom", motCle);
            match = match || contact.RechercherParChamp("prenom", motCle);
            match = match || contact.RechercherParChamp("mail", motCle);
            match = match || contact.RechercherParChamp("telephone", motCle);

            if (match)
            {
               searchResult.Add(contact);
            }
         }
         return searchResult;
      }

      public List<Contact> Rechercher(String motCle, String champ)
      {
         bool match;
         List<Contact> searchResult;

         searchResult = new List<Contact>();

         foreach (Contact contact in this.contenu)
         {
            match = contact.RechercherParChamp(champ, motCle);

            if (match)
            {
               searchResult.Add(contact);
            }
         }
         return searchResult;
      }
   }
}
