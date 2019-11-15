using System.Reflection;
using System.Text;
using ETrade10Common = OkonkwoETrade10.Framework.Common;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10Response : Response
   {
      public AccountListResponse AccountListResponse { get; set; }
      public BalanceResponse BalanceResponse { get; set; }
      public TransactionListResponse TransactionListResponse { get; set; }
      public TransactionDetailsResponse TransactionDetailsResponse { get; set; }

      public QuoteResponse QuoteResponse { get; set; }
   }

   public class Response
   {
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
