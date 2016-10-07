using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
   class Afficheur
   {
      private Menu menu;

      public Afficheur(Menu menu)
      {
         this.menu = menu;
      }

      public void AfficherMenu()
      {
         AfficherLigne("_________________________________________________________________");
         AfficherLigne("Menu : ");
         for(int i = 0; i < this.menu.Actions.Count; i++)
         {
            AfficherLigne(this.menu.Actions[i]);
         }
         AfficherLigne("_________________________________________________________________");
      }

      public void AfficherRepertoire(Repertoire repertoire)
      {
         AfficherLigne("_________________________________________________________________");
         AfficherLigne("Liste des contacts : ");
         if (repertoire.Contenu.Count == 0)
         {
            AfficherLigne("Aucun contact.");
            return;
         }
         foreach (Contact contact in repertoire.Contenu)
         {
            AfficherLigne("-------------------------------------------------------------");
            AfficherContact(contact);
         }
         AfficherLigne("-------------------------------------------------------------");
      }

      public void AfficherErreur(String message)
      {
         String sortie;

         sortie = "ATTENTION ! " + message;
         AfficherLigne(sortie);
      }

      public void AfficherAjoutContact()
      {
         AfficherLigne("_________________________________________________________________");
         AfficherLigne("Ajout d'un contact :");
      }

      public void AfficherRechercherContact()
      {
         AfficherLigne("_________________________________________________________________");
         AfficherLigne("Recherche de contacts :");
         AfficherLigne("Voulez vous rechercher sur un champ précis ?");
      }

      public void AfficherResultatsRecherche(List<Contact> lst)
      {
         AfficherLigne("_________________________________________________________________");
         AfficherLigne("Résultats :");
         if (lst.Count == 0)
         {
            AfficherLigne("Aucun résultat");
               return;
         }
         foreach (Contact contact in lst)
         {
            AfficherLigne("-------------------------------------------------------------");
            AfficherContact(contact);
         }
         AfficherLigne("-------------------------------------------------------------");
      }

      public void AfficherDemande(String str)
      {
         AfficherLigne(str);
      }

      private void AfficherContact(Contact contact)
      {
         String sortie;
         sortie = contact.Affichage();
         AfficherLigne(sortie);
      }

      private void AfficherLigne(String line)
      {
         Console.WriteLine(line);
      }
   }
}
