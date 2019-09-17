using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ETrade10Common = OkonkwoETrade10.Framework.Common;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10Response : Response
   {

   }

   public class Response
   {
      /// <summary>
      /// The ID of the last Transaction created for the Account. Only
      /// present if the Account exists.
      /// </summary>
      public long lastTransactionID { get; set; }

      /// <summary>
      /// The IDs of all Transactions that were created while satisfying the
      /// request. Only present if the Account exists.
      /// </summary>
      public List<long> relatedTransactionIDs { get; set; }

      /// <summary>
      /// Writes the Response object to a JSON string
      /// </summary>
      /// <returns></returns>
      public override string ToString()
      {
         // use reflection to display all the properties that have non default values
         var result = new StringBuilder();
         var properties = GetType().GetTypeInfo().DeclaredProperties;
         result.AppendLine("{");
         foreach (var prop in properties)
         {
            if (prop.Name != "clientExtensions")
            {
               object value = prop.GetValue(this);
               bool valueIsNull = value == null;
               object defaultValue = ETrade10Common.GetDefault(prop.PropertyType);
               bool defaultValueIsNull = defaultValue == null;
               if ((valueIsNull != defaultValueIsNull) // one is null when the other isn't
                   || (!valueIsNull && (value.ToString() != defaultValue.ToString()))) // both aren't null, so compare as strings
               {
                  result.AppendLine(prop.Name + " : " + prop.GetValue(this));
               }
            }
         }
         result.AppendLine("}");
         return result.ToString();
      }
   }

   /// <summary>
   /// The base error response returned by the V20 endpoints
   /// http://developer.oanda.com/rest-live-v20/troubleshooting-errors/
   /// </summary>
   public class ErrorResponse : Response, IErrorResponse
   {
      /// <summary>
      /// The code of the error that has occurred. This field may not be returned 
      /// for some errors.
      /// </summary>
      public string errorCode { get; set; }

      /// <summary>
      /// The human-readable description of the error that has occurred.
      /// </summary>
      public string errorMessage { get; set; }
   }

   /// <summary>
   /// The base error response returned by the V20 endpoints
   /// http://developer.oanda.com/rest-live-v20/troubleshooting-errors/
   /// </summary>
   public interface IErrorResponse
   {
      string errorCode { get; set; }

      string errorMessage { get; set; }
   }

   /// <summary>
   /// Error codes returned from Oanda V20 endpoints
   /// </summary>
   public class ErrorCode
   {
      public const string InvalidRange = "INVALID_RANGE";
   }
}
