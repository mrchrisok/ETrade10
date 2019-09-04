namespace OkonkwoETrade10.Accounts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/account/api-portfolio-v1.html#/definitions/FundamentalView
   /// </summary>
   public class FundamentalView : AccountView
   {
      /// <summary>
      /// The change
      /// </summary>
      public decimal change { get; set; }

      /// <summary>
      /// The change percentage
      /// </summary>
      public decimal changePct { get; set; }

      /// <summary>
      /// The Price to Earnings(P/E) ratio
      /// </summary>
      public decimal peRatio { get; set; }

      /// <summary>
      /// The earnings per share
      /// </summary>
      public decimal eps { get; set; }

      /// <summary>
      /// // The dividend
      /// </summary>
      public decimal dividend { get; set; }

      /// <summary>
      /// The dividend yield
      /// </summary>
      public decimal divYield { get; set; }

      /// <summary>
      /// The market cap
      /// </summary>
      public decimal marketCap { get; set; }

      /// <summary>
      /// The 52 week range
      /// </summary>
      public string week52Range { get; set; }
   }
}
