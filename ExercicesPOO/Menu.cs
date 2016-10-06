using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ExercicesPOO
{
   class Menu
   {
      private List<Contact> repertoire;
      private bool continuer;
      private String fichier;

      public Menu()
      {
         List<Contact> provi;
         fichier = "repertoire.txt";
         provi = this.ReadFile();
         if (provi.Count == 0)
         {
            repertoire = new List<Contact>();
         }
         else
         {
            repertoire = provi;
         }
         continuer = true;
      }

      public bool Continuer
      {
         get { return this.continuer; }
      }

      public void ExecuterCHoix(int choix)
      {
         switch (choix)
         {
            case 1:
               this.AfficherContacts();
               break;
            case 2:
               this.AjouterContact();
               break;
            case 3:
               this.SaveContact();
               break;
            case 4:
               this.Rechercher();
               break;
            case 0:
               this.continuer = false;
               break;
            default:
               Console.WriteLine("Option non valide");
               break;
         }
      }

      public void Afficher()
      {
         Console.WriteLine("__________________________________________________________________________");
         Console.WriteLine("Menu :");
         Console.WriteLine("1 - Afficher la liste des Contacts.");
         Console.WriteLine("2 - Ajouter un Contact.");
         Console.WriteLine("3 - Sauvegarder les contacts");
         Console.WriteLine("4 - Rechercher des contacts");
         Console.WriteLine();
         Console.WriteLine("0 - Quitter le repertoire.");
         Console.WriteLine("__________________________________________________________________________");
      }

      public void AfficherContacts()
      {
         Console.WriteLine("__________________________________________________________________________");
         if (repertoire.Count == 0)
         {
            Console.WriteLine("Aucun contact dans le repertoire");
         }
         foreach (Contact contact in this.repertoire)
         {
            contact.SePresenter(true);
         }
      }

      public void AjouterContact()
      {
         repertoire.Add(new Contact());
      }

      public int RecupererChoix()
      {
         while (true)
         {
            String choix = Console.ReadLine();
            if (choix.Length == 1)
            {
               char caractere = char.Parse(choix);
               if ((caractere > '0') || (caractere < '9'))
               {
                  return int.Parse(choix);
               }
               else
               {
                  Console.WriteLine("Option non valide, veuillez recommencer.");
               }
            }
            else
            {
               Console.WriteLine("Option non valide, veuillez recommencer.");
            }
         }
      }

      public void ChoisirRecherche()
      {
         int choix;
         choix = this.RecupererChoix();

         switch (choix)
         {
            case 1:
               this.RecherchePrecise();
               break;
            case 2:
               this.RechercheLarge();
               break;
            case 0:
               return;
            default:
               Console.WriteLine("Option non valide");
               break;
         }
      }

      public void RechercheLarge()
      {
         String motCle;
         Console.WriteLine("__________________________________________________________________________");
         Console.WriteLine("Mot clé de la recherche :");
         motCle = Console.ReadLine();
         Console.WriteLine("__________________________________________________________________________");
         this.Search(motCle);
      }

      public void RecherchePrecise()
      {
         String motCle;
         String critere;
         Console.WriteLine("__________________________________________________________________________");
         Console.WriteLine("Mot clé de la recherche :");
         motCle = Console.ReadLine();
         Console.WriteLine("Critere de la recherche :");
         critere = Console.ReadLine();
         Console.WriteLine("__________________________________________________________________________");
         this.Search(motCle, critere);
      }

      public void AfficherResultatsRecherche(List<Contact> lst)
      {
         foreach (Contact contact in lst)
         {
            Console.WriteLine("__________________________________________________________________________");
            contact.SePresenter(true);
         }
      }

      public void Search(String motCle)
      {
         bool matchNom;
         bool matchPrenom;
         bool matchTelephone;
         bool matchMail;
         String pattern;
         Regex rgx;
         List<Contact> searchResult;

         pattern= @"[" + motCle + "]";
         rgx = new Regex(pattern);
         searchResult = new List<Contact>();

         foreach (Contact contact in this.repertoire)
         {
            matchNom = (rgx.IsMatch(contact.Nom));
            matchPrenom = (rgx.IsMatch(contact.Prenom));
            matchTelephone = (rgx.IsMatch(contact.Telephone));
            matchMail = (rgx.IsMatch(contact.Mail));

            if (matchNom || matchPrenom || matchTelephone || matchMail)
            {
               searchResult.Add(contact);
            }
         }
         if (searchResult.Count > 0)
         {
            this.AfficherResultatsRecherche(searchResult);
         }
      }

      public void Search(String motCle, String champ)
      {
         bool matchNom;
         bool matchPrenom;
         bool matchTelephone;
         bool matchMail;
         bool match;
         String pattern;
         Regex rgx;
         List<Contact> searchResult;

         pattern = @"[" + motCle.ToUpper() + "]";
         rgx = new Regex(pattern);
         searchResult = new List<Contact>();
         champ = champ.ToUpper();

         foreach (Contact contact in this.repertoire)
         {
            matchNom = (rgx.IsMatch(contact.Nom.ToUpper()));
            matchPrenom = (rgx.IsMatch(contact.Prenom.ToUpper()));
            matchTelephone = (rgx.IsMatch(contact.Telephone.ToUpper()));
            matchMail = (rgx.IsMatch(contact.Mail.ToUpper()));
            match = false;

            if (champ == "PRENOM")
            {
               match = matchPrenom;
            }
            if (champ == "NOM")
            {
               match = matchNom;
            }
            if (champ == "MAIL")
            {
               match = matchMail;
            }
            if (champ == "TELEPHONE")
            {
               match = matchTelephone;
            }
            if (match)
            {
               searchResult.Add(contact);
            }
         }
         if (searchResult.Count > 0)
         {
            this.AfficherResultatsRecherche(searchResult);
         }
      }

      public void Rechercher()
      {
         Console.WriteLine("__________________________________________________________________________");
         Console.WriteLine("1 - Recherche sur un champ précis.");
         Console.WriteLine("2 - Rechercher sur tous les champs");
         Console.WriteLine();
         Console.WriteLine("0 - Quitter le repertoire.");
         Console.WriteLine("__________________________________________________________________________");

         this.ChoisirRecherche();
      }

      public void SaveContact()
      {
         List<Contact> fileContent = this.ReadFile();
         foreach(Contact contact in repertoire)
         {
            if (!fileContent.Contains(contact))
            {
               contact.Enregistrer(this.fichier);
            }
         }
      }

      public List<Contact> ReadFile()
      {
         StreamReader reader = new StreamReader(this.fichier);
         String line;
         List<Contact> provisoire = new List<Contact>();
         while ((line = reader.ReadLine()) != null)
         {
            if (line != "")
            {
               String[] champs;
               champs = line.Split(';');
               if (champs.Length == 2)
               {
                  provisoire.Add(new Contact(champs[0], champs[1]));
               }
               if (champs.Length == 4)
               {
                  provisoire.Add(new Contact(champs[0], champs[1], champs[2], champs[3]));
               }
            }
         }
         reader.Close();
         return provisoire;
      }
   }
}
