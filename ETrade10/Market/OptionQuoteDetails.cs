namespace OkonkwoETrade10.Market
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/OptionQuoteDetails
   /// </summary>
   public class OptionQuoteDetails
   {
      /// <summary>
      /// The current ask price for a security
      /// </summary>
      public decimal ask { get; set; }

      /// <summary>
      /// The number of shares or contracts offered by a broker/dealer at the ask price
      /// </summary>
      public long askSize { get; set; }

      /// <summary>
      /// The current bid price for a security
      /// </summary>
      public decimal bid { get; set; }

      /// <summary>
      /// The number of shares or contracts offered at the bid price
      /// </summary>
      public long bidSize { get; set; }

      /// <summary>
      /// The name of the company associated with the equity, option, or index
      /// </summary>
      public string companyName { get; set; }

      /// <summary>
      /// Number of days before the option expires
      /// </summary>
      public long daysToExpiration { get; set; }

      /// <summary>
      /// The price of the most recent trade in a security
      /// </summary>
      public decimal lastTrade { get; set; }

      /// <summary>
      /// The total number of options or futures contracts that are not closed or delivered on a particular day
      /// </summary>
      public long openInterest { get; set; }

      /// <summary>
      /// The previous bid price for the option
      /// </summary>
      public decimal optionPreviousBidPrice { get; set; }

      /// <summary>
      /// The previous ask price for the option
      /// </summary>
      public decimal optionPreviousAskPrice { get; set; }

      /// <summary>
      /// The Options Symbology Initiative(OSI) representation of the option symbol
      /// </summary>
      public string osiKey { get; set; }

      /// <summary>
      /// The intrinsic value of the share
      /// </summary>
      public decimal intrinsicValue { get; set; }

      /// <summary>
      /// The value of the time premium
      /// </summary>
      public decimal timePremium { get; set; }

      /// <summary>
      /// The value of the option multiplier
      /// </summary>
      public decimal optionMultiplier { get; set; }

      /// <summary>
      /// The contract size of the option
      /// </summary>
      public decimal contractSize { get; set; }

      /// <summary>
      /// The description of the security; for example, company name or option description
      /// </summary>
      public string symbolDescription { get; set; }

      /// <summary>
      /// The Greek values for the option
      /// </summary>
      public OptionGreeks optionGreeks { get; set; }
   }
}
