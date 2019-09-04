namespace OkonkwoETrade10.Market
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/FundamentalQuoteDetails
   /// </summary>
   public class FundamentalQuoteDetails
   {
      /// <summary>
      /// The name of the company associated with the equity, option, or index. 
      /// </summary>
      public string companyName { get; set; }

      /// <summary>
      /// The earnings per share on a rolling basis(Applies to stocks only) 
      /// </summary>
      public decimal eps { get; set; }

      /// <summary>
      /// The estimated earnings
      /// </summary>
      public decimal estEarnings { get; set; }

      /// <summary>
      /// The highest price at which a security has traded during the past year (52 weeks). 
      /// For options, this value is the lifetime high.	
      /// </summary>
      public decimal high52 { get; set; }

      /// <summary>
      /// The most recent trade price for a security 
      /// </summary>
      public decimal lastTrade { get; set; }

      /// <summary>
      /// The lowest price at which a security has traded during the past year (52 weeks). 
      /// For options, this value is the lifetime low.	
      /// </summary>
      public decimal low52 { get; set; }

      /// <summary>
      /// A description of the security, such as company name or option description 
      /// </summary>
      public string symbolDescription { get; set; }

      /// <summary>
      /// Ten-day average trading volume for the security 
      /// </summary>
      public long volume10Day { get; set; }
   }
}
