using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicesPOO.FileManagement
{
   abstract class FileManager
   {
      protected String dataBaseFileName;

      public abstract void Exporter(Repertoire repertoire, String path);

      public abstract List<Contact> LoadFile(String filePath);
   }
}
