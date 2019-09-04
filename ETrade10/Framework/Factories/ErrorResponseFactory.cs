using Newtonsoft.Json;
using OkonkwoETrade10.REST;

namespace OkonkwoETrade10.Framework.Factories
{
   public class ErrorResponseFactory
   {
      public static IErrorResponse Create(string message)
      {
         var dynamicError = JsonConvert.DeserializeObject<dynamic>(message);

         // the 'type' property is injected by the ETrade10.GetWebResponse catch block

         switch (dynamicError.type.ToString())
         {
            case "AccountBalancesErrorResponse":
               return JsonConvert.DeserializeObject<BalanceErrorResponse>(message);
            case "AccountListErrorResponse":
               return JsonConvert.DeserializeObject<AccountListErrorResponse>(message);



            default:
               return JsonConvert.DeserializeObject<ErrorResponse>(message);
         }
      }
   }
}
