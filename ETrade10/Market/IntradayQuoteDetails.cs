namespace OkonkwoETrade10.Market
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/IntradayQuoteDetails
   /// </summary>
   public class IntradayQuoteDetails
   {
      /// <summary>
      /// The current ask price for a security
      /// </summary>
      public decimal ask { get; set; }

      /// <summary>
      /// The current bid price for a security
      /// </summary>
      public decimal bid { get; set; }

      /// <summary>
      /// The dollar change of the last price from the previous close
      /// </summary>
      public decimal changeClose { get; set; }

      /// <summary>
      /// The percentage change of the last price from the previous close
      /// </summary>
      public decimal changeClosePercentage { get; set; }

      /// <summary>
      /// The name of the company associated with the equity, option, or index
      /// </summary>
      public string companyName { get; set; }

      /// <summary>
      /// The highest price at which a security has traded during the current day
      /// </summary>
      public decimal high { get; set; }

      /// <summary>
      /// The price of the last trade
      /// </summary>
      public decimal lastTrade { get; set; }

      /// <summary>
      /// The lowest price at which a security has traded during the current day
      /// </summary>
      public decimal low { get; set; }

      /// <summary>
      /// Total number of shares or contracts exchanging hands
      /// </summary>
      public long totalVolume { get; set; }
   }
}
