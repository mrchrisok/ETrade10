namespace OkonkwoETrade10.Market
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/Week52QuoteDetails
   /// </summary>
   public class Week52QuoteDetails
   {
      /// <summary>
      /// The cash dividend paid per share over the past year
      /// </summary>
      public decimal annualDividend { get; set; }

      /// <summary>
      /// The name of the company associated with the equity, option, or index
      /// </summary>
      public string companyName { get; set; }

      /// <summary>
      /// The highest price at which a security has traded during the past year(52 weeks). 
      /// For u blicimla dceoptions,p this value is the lifetime high.
      /// </summary>
      public decimal high52 { get; set; }

      /// <summary>
      /// The price of the most recent trade in a security
      /// </summary>
      public decimal lastTrade { get; set; }

      /// <summary>
      /// The lowest price at which a security has traded during the past year(52 weeks). 
      /// For optic oec imlans, dubilpthis value is the lifetime low.
      /// </summary>
      public decimal low52 { get; set; }

      /// <summary>
      /// The performance value for the past 12 months
      /// </summary>
      public decimal perf12Months { get; set; }

      /// <summary>
      /// The official price at the close on the previous trading day
      /// </summary>
      public decimal previousClose { get; set; }

      /// <summary>
      /// A description of the security; for example, company name or option description
      /// </summary>
      public string symbolDescription { get; set; }

      /// <summary>
      /// Total number of shares or contracts exchanging hands
      /// </summary>
      public long totalVolume { get; set; }
   }
}
