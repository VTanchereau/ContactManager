using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicesPOO
{
   class Constantes
   {
      public static String ERREUR_FORMAT_ENTIER = "Veuillez entrer un entier s'il vous plait.";
      public static String ERREUR_TAILLE_ENTIER = "Le nombre entré est trop grand ou trop petit.";
      public static String ERREUR_GENERIQUE = "J'ai rencontré une erreur inconnue. #YOLO.";
      public static String ERREUR_FILE_ACCES = "Je n'ai pas accès à ce dossier.";
      public static String ERREUR_IO = "Erreur de lecture ou d'ecriture.";
      public static String ERREUR_PATH_LONG = "Le chemin renseigné est trop long.";
      public static String ERREUR_DIRECTORY_NOT_FOUND = "Le répertoire renseigné n'a pas été trouvé.";
      public static String ERREUR_FILE_NOT_FOUND = "Le fichier renseigné n'a pas été trouvé.";
      public static String ERREUR_FILE_ARGUMENT = "Le chemin spécifié est invalide.";
      public static String ERREUR_FILE_CONTENT_CSV = "Le contenu du fichier ne correspond pas au format .csv (séparateur ';').";
      public static String ERREUR_FILE_CONTENT_TXT = @"
      Le contenu du fichier ne correspond pas au format .txt : \n
         \t50 caractères pour le nom\n
         \t50 caractères pour le prenom\n
         \t15 caractères pour le téléphone\n
         \t50 caractères pour le mail\n";
   }
}
