using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicesPOO
{
   class FileManager
   {
      private String dataBaseFileName;

      public FileManager()
      {
         dataBaseFileName = "repertoire.csv";

         if (!File.Exists(dataBaseFileName))
         {
            File.Create(dataBaseFileName);
         }
      }

      public void Exporter(Repertoire repertoire, String path)
      {
         this.WriteFile(repertoire, path);
      }

      public void Save(Repertoire repertoire)
      {
         this.WriteFile(repertoire, this.dataBaseFileName);
      }

      public void WriteFile(Repertoire repertoire, String path)
      {
         StreamWriter writer = new StreamWriter(path);

         foreach(Contact contact in repertoire.Contenu)
         {
            writer.WriteLine(contact.ToString());
         }

         writer.Close();
      }

      public List<Contact> LoadFile()
      {
         return this.ReadFile(this.dataBaseFileName);
      }

      public List<Contact> LoadFile(String filePath)
      {
         return this.ReadFile(filePath);
      }

      public List<Contact> ReadFile(String path)
      {
         StreamReader reader = new StreamReader(path);
         String line;
         List<Contact> provisoire = new List<Contact>();
         String[] champs;
         while ((line = reader.ReadLine()) != null)
         {
            if (line != "")
            {

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
