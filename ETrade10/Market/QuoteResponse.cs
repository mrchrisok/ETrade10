using System.Collections.Generic;
using OkonkwoETrade10.Common;

namespace OkonkwoETrade10.Market
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/QuoteResponse
   /// </summary>
   public class QuoteResponse
   {
      /// <summary>
      /// The Quote Message Data
      /// </summary>
      public List<QuoteData> quoteData { get; set; }

      /// <summary>
      /// The Quote response Message
      /// </summary>
      public Messages messages { get; set; }
   }
}
