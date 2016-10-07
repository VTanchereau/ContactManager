using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ContactManager
{
   class Menu
   {
      private List<String> actions;
      private bool continuer;
      private UserInput userInput;
      private Afficheur afficheur;
      private Repertoire repertoire;
      private FileManager fileManager;

      public Menu()
      {
         this.actions = new List<String>();
         this.afficheur = new Afficheur(this);
         this.userInput = new UserInput(afficheur);
         this.fileManager = new FileManager();
         this.repertoire = new Repertoire(this.fileManager.LoadFile());
         this.AjouterActions();
         this.continuer = true;

         this.Launch();
      }

      public List<String> Actions
      {
         get { return this.actions; }
      }

      private void Launch()
      {
         while (this.continuer)
         {
            this.afficheur.AfficherMenu();
            int choix;
            choix = int.Parse(userInput.getInput("", new ValidateurInt()));
            this.TraiterChoix(choix);
         }
      }

      private void TraiterChoix(int choix)
      {
         switch (choix)
         {
            case 0:
               this.continuer = false;
               break;
            case 1:
               this.ListerContacts();
               break;
            case 2:
               this.AjouterContact();
               break;
            case 3:
               this.Rechercher();
               break;
            case 4:
               this.Charger();
               break;
            case 5:
               this.Sauvegarder();
               break;
            case 6:
               this.Exporter();
               break;
            case 7:
               this.RetirerContact();
               break;
            default:
               this.afficheur.AfficherErreur("Le chiffre entré ne correspond à aucune action du menu.");
               break;
         }
      }

      private void RetirerContact()
      {
         List<Contact> resultats;
         int choix;
         bool boucle;

         while (true)
         {
            resultats = this.Rechercher();
            boucle = true;

            while (boucle)
            {
               this.afficheur.AfficherDemande("1 - Supprimer les contacts selectionnés.");
               this.afficheur.AfficherDemande("2 - Effectuer une nouvelle recherche.");
               this.afficheur.AfficherDemande("");
               this.afficheur.AfficherDemande("0 - Abbandonner la suppression de contacts.");

               choix = int.Parse(userInput.getInput("", new ValidateurInt()));
               if (choix == 1)
               {
                  if(resultats.Count > 0)
                  {
                     foreach (Contact contact in resultats)
                     {
                        this.repertoire.Contenu.Remove(contact);
                     }
                     if (resultats.Count > 1)
                     {
                        this.afficheur.AfficherDemande("Les contacts ont bien été supprimés.");
                     }
                     else
                     {
                        this.afficheur.AfficherDemande("Le contact a bien été supprimé. (pensez à sauvegarder le répertoire pour enregistrer la suppression)");
                     }
                     return;
                  }
                  else
                  {
                     this.afficheur.AfficherErreur("Aucuns contacts ne sont sélectionnés.");
                     boucle = false;
                  }
               }
               else if (choix == 2)
               {
                  boucle = false;
               }
               else if (choix == 0)
               {
                  return;
               }
               else
               {
                  this.afficheur.AfficherErreur("Le chiffre entré ne correspond à aucune action du menu.");
               }
            }
         }
      }

      private void Exporter()
      {
         String path;

         path = this.userInput.getInput("Chemin du fichier.", new ValidateurPath());
         this.fileManager.Exporter(this.repertoire, path);
         this.afficheur.AfficherDemande("Le fichier a bien été exporté.");
      }

      private void Sauvegarder()
      {
         this.fileManager.Save(this.repertoire);
         this.afficheur.AfficherDemande("Le fichier a bien été sauvegardé.");
      }

      private void Charger()
      {
         String path;

         path = this.userInput.getInput("Chemin du fichier.", new ValidateurPath());
         this.fileManager.LoadFile(path);
         this.afficheur.AfficherDemande("Le fichier a bien été chargé.");
      }

      private void ListerContacts()
      {
         this.afficheur.AfficherRepertoire(this.repertoire);
      }

      private List<Contact> Rechercher()
      {
         String motCle;
         bool precise;
         List<Contact> result;

         this.afficheur.AfficherRechercherContact();
         precise = this.userInput.getInput("", new ValidateurBool()).ToUpper() == "OUI";
         motCle = this.userInput.getInput("Entrez un mot clé :",new  ValidateurWords());
         if (precise)
         {
            this.afficheur.AfficherDemande("Entrez un champ :");
            String champ = this.userInput.getInput("Entrez un champ :", new ValidateurChamp());
            result = this.repertoire.Rechercher(motCle, champ);
         }
         else
         {
            result = this.repertoire.Rechercher(motCle);
         }

         this.afficheur.AfficherResultatsRecherche(result);
         return result;
      }

      private void AjouterContact()
      {
         String prenom;
         String nom;
         bool moreInfos;

         this.afficheur.AfficherAjoutContact();
         prenom = this.userInput.getInput("Entrez le prénom :", new ValidateurWords());
         nom = this.userInput.getInput("Entrez le nom :", new ValidateurWords());
         moreInfos = this.userInput.getInput("Voulez vous renseigner le numéro de téléphone et le mail ?", new ValidateurBool()).ToUpper() == "OUI";
         if (moreInfos)
         {
            String telephone = this.userInput.getInput("Entrez le téléphone :", new ValidateurPhoneNumber());
            String mail = this.userInput.getInput("Entrez le mail :", new ValidateurMail());
            this.repertoire.Add(new Contact(nom, prenom, telephone, mail));
         }
         else
         {
            this.repertoire.Add(new Contact(nom, prenom));
         }
      }

      private void AjouterActions()
      {
         this.actions.Add("1 - Afficher la liste des contacts.");
         this.actions.Add("2 - Ajouter un contact.");
         this.actions.Add("3 - Rechercher des contacts.");
         this.actions.Add("4 - Charger un fichier.");
         this.actions.Add("5 - Sauvegarder le répertoire.");
         this.actions.Add("6 - Exporter le répertoire.");
         this.actions.Add("7 - Supprimer un ou des contacts.");
         // Ajouter les nouvelles actions ici
         this.actions.Add("");
         this.actions.Add("0 - Quittez le repertoire.");
      }
   }
}
