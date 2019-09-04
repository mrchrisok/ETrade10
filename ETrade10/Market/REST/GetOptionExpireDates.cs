using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using OkonkwoETrade10.Market;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// Returns a list of dates suitable for structuring an option table display. The dates are used to group option data (returned by the optionchains method) for a specified underlier, creating a table display.
      /// https://apisb.etrade.com/docs/api/market/api-market-v1.html#/definition/getOptionExpireDates
      /// </summary>
      /// <param name="parameters">The request parameters</param>
      /// <returns>An OptionExpireDateResponse object</returns>
      public static async Task<List<ExpirationDate>> GetOptionExpireDatesAsync(OptionExpireDateParameters parameters)
      {
         string uri = ServerUri(EServer.Market) + "/optionexpiredate";

         var requestParams = ConvertToDictionary(parameters);

         var response = await MakeRequestAsync<OptionExpireDateResponse, OptionExpireDateErrorResponse>(uri, requestParams: requestParams);

         return response.expirationDates;
      }

      public class OptionExpireDateParameters
      {
         /// <summary>
         /// Expiration type of the option
         /// </summary>
         [DataMember(EmitDefaultValue = false)]
         public string expiryType { get; set; }

         /// <summary>
         /// The symbol in the request
         /// </summary>
         public string symbol { get; set; }
      }
   }

   /// <summary>
   /// The GET success response
   /// https://apisb.etrade.com/docs/api/market/api-market-v1.html#/definitions/OptionExpireDateResponse
   /// </summary>
   public class OptionExpireDateResponse : Response
   {
      /// <summary>
      /// The expiration dates for the options
      /// </summary>
      public List<ExpirationDate> expirationDates { get; set; }
   }

   /// <summary>
   /// The GET error response received from the accounts/accountID
   /// </summary>
   public class OptionExpireDateErrorResponse : ErrorResponse
   {
   }
}
