using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ExercicesPOO
{
   class Menu
   {
      private List<String> actions;
      private bool continuer;
      private UserInput userInput;
      private Afficheur afficheur;
      private Repertoire repertoire;
      private FileManagement.FileManager fileManager;

      public Menu()
      {
         this.actions = new List<String>();
         this.afficheur = new Afficheur(this);
         this.userInput = new UserInput(afficheur, this);
         this.repertoire = new Repertoire(new FileManagement.FileManagerCSV().LoadFile());
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
            String choix;
            choix = userInput.getInput("", new Validateurs.ValidateurWords());
            this.TraiterChoix(choix);
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

               choix = int.Parse(userInput.getInput("", new Validateurs.ValidateurInt()));
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
         String choice;
         String fileName;

         choice = this.userInput.getInput("Format CSV ou TXT ?", new Validateurs.ValidateurWords());
         path = this.userInput.getInput("Dans quel dossier enregistrer le fichier ?", new Validateurs.ValidateurPath());
         fileName = this.userInput.getInput("Nom du fichier : ", new Validateurs.ValidateurWords());

         if (!path.EndsWith("\\"))
         {
            path += "\\";
         }

         if (choice.ToUpper() == "CSV")
         {
            if (!fileName.EndsWith(".csv"))
            {
               fileName += ".csv";
            }
            this.fileManager = new FileManagement.FileManagerCSV();
         }
         else if (choice.ToUpper() == "TXT")
         {
            if (!fileName.EndsWith(".txt"))
            {
               fileName += ".txt";
            }
            this.fileManager = new FileManagement.FileManagerTXT();
         }

         path += fileName;
         try
         {
            this.fileManager.Exporter(this.repertoire, path);
            this.afficheur.AfficherDemande("Le fichier a bien été exporté.");
         }
         catch (Exceptions.FileManagerException e)
         {
            this.afficheur.AfficherErreur("Erreur dans l'exportation du repertoire.");
            this.afficheur.AfficherErreur(e.Message);
         }
      }

      private void Sauvegarder()
      {
         try
         {
            new FileManagement.FileManagerCSV().Save(this.repertoire);
            this.afficheur.AfficherDemande("Le fichier a bien été sauvegardé.");
         }
         catch (Exceptions.FileManagerException e)
         {
            this.afficheur.AfficherErreur("Erreur dans la sauvegarde du repertoire.");
            this.afficheur.AfficherErreur(e.Message);
         }
      }

      private void Charger()
      {
         String path;
         String choice;

         choice = this.userInput.getInput("Format CSV ou TXT ?", new Validateurs.ValidateurWords());
         path = this.userInput.getInput("Chemin du fichier :", new Validateurs.ValidateurPath());

         if (choice.ToUpper() == "CSV")
         {
            this.fileManager = new FileManagement.FileManagerCSV();
         }
         else if (choice.ToUpper() == "TXT")
         {
            this.fileManager = new FileManagement.FileManagerTXT();
         }

         try
         {
            this.fileManager.LoadFile(path);
            this.afficheur.AfficherDemande("Le fichier a bien été chargé.");
         }
         catch (Exceptions.FileManagerException e)
         {
            this.afficheur.AfficherErreur("Erreur dans le chargement du fichier.");
            this.afficheur.AfficherErreur(e.Message);
         }
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
         precise = this.userInput.getInput("", new Validateurs.ValidateurBool()).ToUpper() == "OUI";
         motCle = this.userInput.getInput("Entrez un mot clé :",new Validateurs.ValidateurWords());
         if (precise)
         {
            this.afficheur.AfficherDemande("Entrez un champ :");
            String champ = this.userInput.getInput("Entrez un champ :", new Validateurs.ValidateurChamp());
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

         this.afficheur.AfficherAjoutContact();
         prenom = this.userInput.getInput("Entrez le prénom :", new Validateurs.ValidateurWords());
         nom = this.userInput.getInput("Entrez le nom :", new Validateurs.ValidateurWords());
         String telephone = this.userInput.getInput("Entrez le téléphone :", new Validateurs.ValidateurPhoneNumber());
         String mail = this.userInput.getInput("Entrez le mail :", new Validateurs.ValidateurMail());
         this.repertoire.Add(new Contact(nom, prenom, telephone, mail));
      }

      public static bool IsAction(int act)
      {
         if ( (act >= 0) || (act < 8)){
            return true;
         }
         else
         {
            return false;
         }
      }

      private void TraiterChoix(String choix)
      {
         switch (choix.ToUpper())
         {
            case "0":
            case "Q":
            case "QUITTER":
            case "QUIT":
               this.continuer = false;
               break;
            case "1":
            case "L":
            case "LIST":
            case "LISTE":
            case "LISTER":
               this.ListerContacts();
               break;
            case "2":
            case "A":
            case "AJOUT":
            case "AJOUTER":
            case "ADD":
               this.AjouterContact();
               break;
            case "3":
            case "R":
            case "RECHERCHER":
            case "RECHERCHE":
            case "SEARCH":
               this.Rechercher();
               break;
            case "4":
            case "C":
            case "CHARGER":
            case "LOAD":
               this.Charger();
               break;
            case "5":
            case "S":
            case "SAVE":
            case "SAUVER":
            case "SAUVEGARDER":
               this.Sauvegarder();
               break;
            case "6":
            case "E":
            case "EXPORT":
            case "EXPORTER":
               this.Exporter();
               break;
            case "7":
            case "SUPPR":
            case "SUPPRIMER":
            case "DELETE":
            case "D":
               this.RetirerContact();
               break;
            default:
               this.afficheur.AfficherErreur("Veuillez choisir une action faisant partie du menu s'il vous plait.");
               break;
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
