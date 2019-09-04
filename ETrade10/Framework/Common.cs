using System;
using System.Reflection;

namespace OkonkwoETrade10.Framework
{
   public class Common
   {
      public static object GetDefault(Type t)
      {
         return typeof(Common).GetTypeInfo().GetDeclaredMethod("GetDefaultGeneric").MakeGenericMethod(t).Invoke(null, null);
      }

      public static T GetDefaultGeneric<T>()
      {
         return default(T);
      }
   }

   public enum AcceptDatetimeFormat
   {
      RFC3339,
      Unix
   }
}
