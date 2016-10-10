using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicesPOO.FileManagement
{
   class FileManagerTXT : FileManager
   {

      public override void Exporter(Repertoire repertoire, String path)
      {
         StreamWriter writer;
         try
         {
            writer = new StreamWriter(path);
         }
         catch (UnauthorizedAccessException e)
         {
            throw new Exceptions.FileManagerException(Constantes.ERREUR_FILE_ACCES, e);
         }
         catch (ArgumentException e)
         {
            throw new Exceptions.FileManagerException(Constantes.ERREUR_FILE_ARGUMENT, e);
         }
         catch (DirectoryNotFoundException e)
         {
            throw new Exceptions.FileManagerException(Constantes.ERREUR_DIRECTORY_NOT_FOUND, e);
         }
         catch (PathTooLongException e)
         {
            throw new Exceptions.FileManagerException(Constantes.ERREUR_PATH_LONG, e);
         }
         catch (IOException e)
         {
            throw new Exceptions.FileManagerException(Constantes.ERREUR_IO, e);
         }
         catch (Exception e)
         {
            throw new Exceptions.FileManagerException(Constantes.ERREUR_GENERIQUE, e);
         }

         foreach (Contact contact in repertoire.Contenu)
         {
            writer.WriteLine(contact.ExtractTXT());
         }

         writer.Close();
      }

      public override List<Contact> LoadFile(string filePath)
      {
         StreamReader reader;
         try
         {
            reader = new StreamReader(filePath);
         }
         catch (ArgumentException e)
         {
            throw new Exceptions.FileManagerException(Constantes.ERREUR_FILE_ARGUMENT, e);
         }
         catch (FileNotFoundException e)
         {
            throw new Exceptions.FileManagerException(Constantes.ERREUR_FILE_NOT_FOUND, e);
         }
         catch (DirectoryNotFoundException e)
         {
            throw new Exceptions.FileManagerException(Constantes.ERREUR_DIRECTORY_NOT_FOUND, e);
         }
         catch (IOException e)
         {
            throw new Exceptions.FileManagerException(Constantes.ERREUR_IO, e);
         }
         catch (Exception e)
         {
            throw new Exceptions.FileManagerException(Constantes.ERREUR_GENERIQUE, e);
         }
         String line;
         String nom;
         String prenom;
         String telephone;
         String mail;
         List<Contact> lstContact = new List<Contact>();
         while ((line = reader.ReadLine()) != null)
         {
            if (line.Length == 165)
            {
               try
               {
                  prenom = line.Substring(0, 50);
                  nom = line.Substring(50, 50);
                  telephone = line.Substring(100, 15);
                  mail = line.Substring(115, 50);
               }
               catch (ArgumentOutOfRangeException e)
               {
                  throw new Exceptions.FileManagerException(Constantes.ERREUR_FILE_CONTENT_TXT, e);
               }

               nom = nom.TrimEnd(' ');
               prenom = prenom.TrimEnd(' ');
               telephone = telephone.TrimEnd(' ');
               mail = mail.TrimEnd(' ');

               lstContact.Add(new Contact(nom, prenom, telephone, mail));
            }
            else
            {
               throw new Exceptions.FileManagerException(Constantes.ERREUR_FILE_CONTENT_TXT);
            }
         }
         reader.Close();
         return lstContact;
      }
   }
}
