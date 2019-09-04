using System.Collections.Generic;
using System.Threading.Tasks;
using OkonkwoETrade10.Market;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// This API returns a list of securities of a specified type (e.g., equity stock) based on a full or partial match of any part of the company name. For instance, a search for "jones" returns a list of securities associated with "Jones Soda Co", "Stella Jones Inc", and many others. The list contains the company name, the exchange that lists the security, the security type, and the symbol, for as many matches as are found. The result may include some unexpected matches, because the search includes more than just the display version of the company name. For instance, searching on "etrade" returns securities for "E TRADE" - notice the space in the name. This API is for searching on the company name, not a security symbol. It's commonly used to look up a symbol based on the company name, e.g., "What is the symbol for Google stock?". To look up company information based on a symbol, or to find detailed information on a security, use the quote API.
      /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html
      /// </summary>
      /// <param name="search">The search request</param>
      /// <returns>A QuoteResponse object</returns>
      public static async Task<LookupResponse> LookupProductAsync(string search)
      {
         string uri = ServerUri(EServer.Market) + $"lookup/{search}";

         var response = await MakeRequestAsync<LookupResponse, LookupErrorResponse>(uri);

         return response;
      }
   }

   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-market-v1.html#/definitions/LookupResponse
   /// </summary>
   public class LookupResponse : Response
   {
      /// <summary>
      /// The lookup response data
      /// </summary>
      public List<Data> data { get; set; }
   }

   /// <summary>
   /// The GET error response.
   /// </summary>
   public class LookupErrorResponse : ErrorResponse
   {
   }
}
