namespace OkonkwoETrade10.Accounts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/account/api-portfolio-v1.html#/definitions/QuickView
   /// </summary>
   public class QuickView : AccountView
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
      /// The total volume
      /// </summary>
      public long volume { get; set; }

      /// <summary>
      /// The seven day current yield
      /// </summary>
      public decimal sevenDayCurrentYield { get; set; }

      /// <summary>
      /// The total annual return
      /// </summary>
      public decimal annualTotalReturn { get; set; }

      /// <summary>
      /// The weighted average maturity
      /// </summary>
      public decimal weightedAverageMaturity { get; set; }
   }
}
