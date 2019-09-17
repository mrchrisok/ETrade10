using System;

namespace OkonkwoETrade10.Core
{
   public static class Arg
   {
      public static void NotNull(string name, [ValidatedNotNull] object value)
      {
         if (value == null)
         {
            throw new ArgumentNullException(name);
         }
      }
   }
}
