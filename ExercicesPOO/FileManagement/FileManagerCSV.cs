using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicesPOO.FileManagement
{
   class FileManagerCSV : FileManager
   {
      public FileManagerCSV()
      {
         this.dataBaseFileName = "repertoire.csv";

         if (!File.Exists(this.dataBaseFileName))
         {
            File.Create(this.dataBaseFileName);
         }
      }

      public override void Exporter(Repertoire repertoire, String path)
      {
         this.WriteFile(repertoire, path);
      }

      public void Save(Repertoire repertoire)
      {
         this.WriteFile(repertoire, this.dataBaseFileName);
      }

      public void WriteFile(Repertoire repertoire, String path)
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
            writer.WriteLine(contact.ExtractCSV());
         }

         writer.Close();
      }

      public List<Contact> LoadFile()
      {
         return this.LoadFile(this.dataBaseFileName);
      }

      public override List<Contact> LoadFile(String path)
      {
         StreamReader reader;
         try
         {
            reader = new StreamReader(path);
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
         List<Contact> provisoire = new List<Contact>();
         String[] champs;
         while ((line = reader.ReadLine()) != null)
         {
            if (line != "")
            {

               champs = line.Split(';');
               if (champs.Length == 4)
               {
                  provisoire.Add(new Contact(champs[1], champs[0], champs[2], champs[3]));
               }
               else
               {
                  throw new Exceptions.FileManagerException(Constantes.ERREUR_FILE_CONTENT_CSV);
               }
            }
         }
         reader.Close();
         return provisoire;
      }
   }
}
