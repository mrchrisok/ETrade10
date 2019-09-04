namespace OkonkwoETrade10.Accounts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/account/api-portfolio-v1.html#/definitions/PerformanceView
   /// </summary>
   public class PerformanceView : AccountView
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
      /// The gain over the day
      /// </summary>
      public decimal daysGain { get; set; }

      /// <summary>
      /// The total gain
      /// </summary>
      public decimal totalGain { get; set; }

      /// <summary>
      /// The total gain percentage
      /// </summary>
      public decimal totalGainPct { get; set; }

      /// <summary>
      /// The market value
      /// </summary>
      public decimal marketValue { get; set; }
   }
}
