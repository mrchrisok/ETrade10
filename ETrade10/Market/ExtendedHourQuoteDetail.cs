namespace OkonkwoETrade10.Market
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/ExtendedHourQuoteDetail
   /// </summary>
   public class ExtendedHourQuoteDetail
   {
      /// <summary>
      /// The price of the most recent trade of a security
      /// </summary>
      public decimal lastPrice { get; set; }

      /// <summary>
      /// The dollar value of the difference between the previous and the present executed price
      /// </summary>
      public decimal change { get; set; }

      /// <summary>
      /// The percentage value of difference between the previous and the present executed price
      /// </summary>
      public decimal percentChange { get; set; }

      /// <summary>
      /// The bid price of the symbol
      /// </summary>
      public decimal bid { get; set; }

      /// <summary>
      /// The number of shares or contracts offered by a broker or dealer at the bid price
      /// </summary>
      public long bidSize { get; set; }

      /// <summary>
      /// The ask price of the symbol	
      /// </summary>
      public decimal ask { get; set; }

      /// <summary>
      /// The number of shares or contracts offered by a broker or dealer at the ask price
      /// </summary>
      public long askSize { get; set; }

      /// <summary>
      /// The number of shares or contracts
      /// </summary>
      public long volume { get; set; }

      /// <summary>
      /// The time when the last trade was carried out for the symbol
      /// </summary>
      public long timeOfLastTrade { get; set; }

      /// <summary>
      /// The time zone corresponding to the timestamp provided in the quote response
      /// </summary>
      public string timeZone { get; set; }

      /// <summary>
      /// The status of the quote, either delayed or real time  REALTIME, DELAYED, CLOSING, EH_REALTIME, EH_BEFORE_OPEN, EH_CLOSED
      /// </summary>
      public string quoteStatus { get; set; }
   }
}
