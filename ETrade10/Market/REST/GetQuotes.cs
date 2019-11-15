using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OkonkwoETrade10.Common;
using OkonkwoETrade10.Market;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// This API retrieves the quote information for one or more specified symbols.
      /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html
      /// </summary>
      /// <param name="symbols">Comma separated list of symbols list. Maximum returned is 25</param>
      /// <returns>A QuoteResponse object</returns>
      public async Task<QuoteResponse> GetQuotesAsync(IEnumerable<string> symbols, QuoteParameters parameters = null)
      {
         symbols = symbols.Take((parameters?.overrideSymbolCount ?? false) ? 50 : 25).ToList();

         string uri = ServerUri(EServer.Market) + $"quote/{GetCommaSeparatedString(symbols)}";

         var requestParameters = ConvertToDictionary(parameters);
         var response = await MakeRequestAsync<QuoteErrorResponse>(uri, requestParams: requestParameters);

         return response.QuoteResponse;
      }

      public class QuoteParameters
      {
         /// <summary>
         /// Determines the market fields returned from a quote request.
         /// Allowable values: ALL, FUNDAMENTAL, INTRADAY, OPTIONS, WEEK_52, MF_DETAIL
         /// </summary>
         public string detailFlag { get; set; }

         /// <summary>
         /// If value is true, then nextEarningDate will be provided in the output. 
         /// If value is false or if the field is not passed, nextEarningDate will be returned with no value.	
         /// </summary>
         public bool requireEarningsDate { get; set; }

         /// <summary>
         /// If value is true, then symbolList may contain a maximum of 50 symbols; otherwise, symbolList can only contain 25 symbols.	
         /// </summary>
         public bool overrideSymbolCount { get; set; }

         /// <summary>
         /// If value is true, no call is made to the service to check whether the symbol has mini options. 
         /// If value is false or if the field is not specified, a service call is made to check if the symbol has mini options.	
         /// </summary>
         public bool skipMiniOptionsCheck { get; set; }
      }
   }

   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/QuoteResponse
   /// </summary>
   public class QuoteResponse
   {
      /// <summary>
      /// The Quote Message Data
      /// </summary>
      public List<QuoteData> QuoteData;

      /// <summary>
      /// The Quote response Message 
      /// </summary>
      public Messages messages { get; set; }
   }

   /// <summary>
   /// The GET error response.
   /// </summary>
   public class QuoteErrorResponse : ErrorResponse
   {
   }
}
