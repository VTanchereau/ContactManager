using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicesPOO
{
   class ValidateurException : Exception
   {
      public ValidateurException(String message)
         : base (message)
      {
      }

      public ValidateurException(String message, Exception innerException)
         : base (message, innerException)
      {
      }
   }
}
