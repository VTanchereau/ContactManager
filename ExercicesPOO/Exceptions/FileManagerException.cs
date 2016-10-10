using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicesPOO.Exceptions
{
   class FileManagerException : Exception
   {
      public FileManagerException(String message)
         : base (message)
      {
      }

      public FileManagerException(String message, Exception innerException)
         : base (message, innerException)
      {
      }
   }
}
