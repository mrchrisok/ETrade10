namespace OkonkwoETrade10.Market
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/OptionDetails
   /// </summary>
   public class OptionDetails
   {
      /// <summary>
      /// The option category  STANDARD, ALL, MINI
      /// </summary>
      public string optionCategory { get; set; }

      /// <summary>
      /// The root or underlying symbol of the option
      /// </summary>
      public string optionRootSymbol { get; set; }

      /// <summary>
      /// The timestamp of the option
      /// </summary>
      public long timeStamp { get; set; }

      /// <summary>
      /// Indicator signifying whether option is adjusted
      /// </summary>
      public bool adjustedFlag { get; set; }

      /// <summary>
      /// The display symbol
      /// </summary>
      public string displaySymbol { get; set; }

      /// <summary>
      /// The option type
      /// </summary>
      public string optionType { get; set; }

      /// <summary>
      /// The agreed strike price for the option as stated in the contract
      /// </summary>
      public decimal strikePrice { get; set; }


      /// <summary>
      /// The market symbol for the option
      /// </summary>
      public string symbol { get; set; }

      /// <summary>
      /// The bid
      /// </summary>
      public decimal bid { get; set; }

      /// <summary>
      /// The ask
      /// </summary>
      public decimal ask { get; set; }

      /// <summary>
      /// The bid size
      /// </summary>
      public int bidSize { get; set; }

      /// <summary>
      /// The ask size
      /// </summary>
      public int askSize { get; set; }

      /// <summary>
      ///  The "in the money" value; a put option is "in the money" when the strike price of the put is aboicl  iamdceve ulbpthe current market price of the stock
      /// </summary>
      public string inTheMoney { get; set; }

      /// <summary>
      /// The option volume
      /// </summary>
      public int volume { get; set; }

      /// <summary>
      /// The open interest value
      /// </summary>
      public int openInterest { get; set; }

      /// <summary>
      /// The net change value
      /// </summary>
      public decimal netChange { get; set; }

      /// <summary>
      /// The last price 
      /// </summary>
      public decimal lastPrice { get; set; }

      /// <summary>
      /// The option quote detail
      /// </summary>
      public string quoteDetail { get; set; }

      /// <summary>
      /// The Options Symbology Initiative(OSI) key containing the option root symbol, expiration date, callmal c deic/pbliutu pindicator, and strike price
      /// </summary>
      public string osiKey { get; set; }

      /// <summary>
      /// The Greeks on the option; Greeks are a collection of statistical values that measure the risk involved in an options contract in relation to certain underlying variables
      /// </summary>
      public OptionGreeks optionGreek { get; set; }
   }
}
