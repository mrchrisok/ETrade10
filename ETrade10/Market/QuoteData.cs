using Newtonsoft.Json;
using OkonkwoETrade10.Common;

namespace OkonkwoETrade10.Market
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/QuoteData
   /// </summary>
   public class QuoteData
   {
      /// <summary>
      /// The date and time of the quote
      /// </summary>
      public string dateTime { get; set; }

      /// <summary>
      /// The date and time of the quote in Coordinated Universal Time (UTC)
      /// </summary>
      public long dateTimeUTC { get; set; }

      /// <summary>
      /// The status of the quote; possible values are: REALTIME, DELAYED, CLOSING, EH_REALTIME, EH_BEFORE_OPEN, or EH_CLOSED  REALTIME, DELAYED, CLOSING, EH_REALTIME, EH_BEFORE_OPEN, EH_CLOSED
      /// </summary>
      public string quoteStatus { get; set; }

      /// <summary>
      /// Indicates whether the quote details are being displayed after hours or not
      /// </summary>
      public bool ahFlag { get; set; }

      /// <summary>
      /// The Quote API will not populate any value for an invalid symbol. When an invalid symbol is requested, the API returns the Messages structure as part of QuoteResponse instead of using the errorMessage string in QuoteData. For this reason, Quote API clients should refer to Messages in the QuoteResponse.	
      /// </summary>
      public string errorMessage { get; set; }

      #region QuoteDetails

      /// <summary>
      /// This field is returned only if the QuoteResponse.detailFlag input parameter is 'ALL'.
      /// </summary>
      [JsonProperty("All")]
      public AllQuoteDetails all { get; set; }

      /// <summary>
      /// This field is returned only if the QuoteResponse.detailFlag input parameter is 'ALL'.
      /// </summary>
      public FundamentalQuoteDetails fundamental { get; set; }

      /// <summary>
      /// The quote details to be displayed. This field depends on the detailFlag input parameter. For example, if detailFlag is ALL, AllQuoteDetails are displayed.If detailFlag is MF_DETAIL, the MutualFund structure gets displayed.
      /// </summary>
      public IntradayQuoteDetails intraday { get; set; }

      /// <summary>
      /// The quote details to be displayed. This field depends on the detailFlag input parameter. 
      /// For example, if detailFlag is ALL, AllQuoteDetails are displayed.If detailFlag is MF_DETAIL, the MutualFund structure gets displayed.
      /// </summary>
      public OptionQuoteDetails option { get; set; }

      /// <summary>
      /// The quote details to be displayed. This field depends on the detailFlag input parameter. 
      /// For example, if detailFlag is ALL, AllQuoteDetails are displayed.
      /// If detailFlag is MF_DETAIL, the MutualFund structure gets displayed.
      /// </summary>
      public Week52QuoteDetails week52 { get; set; }

      #endregion

      /// <summary>
      /// The product details for the symbol the quote has been requested for
      /// </summary>
      [JsonProperty("Product")]
      public Product product { get; set; }

      /// <summary>
      /// The quote details to be displayed. This field depends on the detailFlag input parameter. 
      /// For example, if detailFlag is ALL, AllQuoteDetails are displayed.
      /// If detailFlag is MF_DETAIL, the MutualFund structure gets displayed.
      /// </summary>
      public MutualFund mutualFund { get; set; }

      /// <summary>
      /// Indicates whether the time zone is set.This field is displayed only when detailFlag is MF_DETAIL.
      /// </summary>
      public string timeZone { get; set; }

      /// <summary>
      /// Indicates whether the daylight savings flag is set.This field is displayed only when detailFlag is MF_DETAIL.
      /// </summary>
      public bool dstFlag { get; set; }

      /// <summary>
      /// Value is true if mini options exist for the symbol; otherwise, value is false. 
      /// This field will only be populated when the symbol is an equity or an index and the skipMiniOptionsCheck parameter is set to false or not provided in the request.
      /// </summary>
      public bool hasMiniOptions { get; set; }
   }
}
