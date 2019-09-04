using System.Collections.Generic;
using System.Threading.Tasks;
using OkonkwoETrade10.Market;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// This API returns a list of option chains for a specific underlying instrument. The request must specify an instrument, the month the option expires, and whether you are interested in calls, puts, or both. Values returned include the option pair count and information about each option pair, including the type, call count, symbol, product, date, and strike price..
      /// https://apisb.etrade.com/docs/api/market/api-market-v1.html#/definition/getOptionChains
      /// </summary>
      /// <param name="parameters">The alerts list parameters</param>
      /// <returns>An AlertsResponse object</returns>
      public static async Task<OptionChainResponse> GetOptionChainAsync(OptionChainParameters parameters)
      {
         string uri = ServerUri(EServer.Market) + $"optionchains";

         var requestParams = ConvertToDictionary(parameters);

         var response = await MakeRequestAsync<OptionChainResponse, OptionChainErrorResponse>(uri, requestParams: requestParams);

         return response;
      }

      public class OptionChainParameters
      {
         /// <summary>
         /// The market symbol for the instrument; for example, GOOG
         /// </summary>
         public short symbol { get; set; }

         /// <summary>
         /// Indicates the expiry year corresponding to which the optionchain needs to be fetched
         /// </summary>
         public short expiryYear { get; set; }

         /// <summary>
         /// Indicates the expiry month corresponding to which the optionchain needs to be fetched
         /// </summary>
         public short expiryMonth { get; set; }

         /// <summary>
         /// Indicates the expiry day corresponding to which the optionchain needs to be fetched
         /// </summary>
         public short expiryDay { get; set; }

         /// <summary>
         /// The optionchians fetched will have strike price nearer to this value
         /// </summary>
         public decimal strikePriceNear { get; set; }

         /// <summary>
         /// Indicates number of strikes for which the optionchain needs to be fetched
         /// </summary>
         public short noOfStrikes { get; set; }

         /// <summary>
         /// The include weekly options request. Default: false
         /// </summary>
         public bool includeWeekly { get; set; }

         /// <summary>
         /// The skip adjusted request. Default: true.
         /// </summary>
         public bool skipAdjusted { get; set; }

         /// <summary>
         /// The option category. Default: STANDARD.STANDARD, ALL, MINI
         /// </summary>
         public string optionCategory { get; set; }

         /// <summary>
         /// The type of option chain.Default: CALLPUT.CALL, PUT, CALLPUT
         /// </summary>
         public string chainType { get; set; }

         /// <summary>
         /// The price type. Default: ATNM.ATNM, ALL
         /// </summary>
         public string priceType { get; set; }
      }
   }

   /// <summary>
   /// The GET success response
   /// </summary>
   public class OptionChainResponse : Response
   {
      public List<OptionChainPair> optionPairs { get; set; }
      public long timeStamp { get; set; }
      public string quoteType { get; set; }
      public decimal nearPrice { get; set; }
      public SelectedED selected { get; set; }
   }

   /// <summary>
   /// The GET error response received from the accounts/accountID
   /// </summary>
   public class OptionChainErrorResponse : ErrorResponse
   {
   }
}
