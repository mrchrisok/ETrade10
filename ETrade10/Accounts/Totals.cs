namespace OkonkwoETrade10.Accounts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/account/api-portfolio-v1.html#/definitions/Totals
   /// </summary>
   public class Totals
   {
      /// <summary>
      /// Today's gain or loss
      /// </summary>
      public decimal todaysGainLoss { get; set; }

      /// <summary>
      /// Today's gain or loss percentage
      /// </summary>
      public decimal todaysGainLossPct { get; set; }

      /// <summary>
      /// Today's market value
      /// </summary>
      public decimal totalMarketValue { get; set; }

      /// <summary>
      /// The total gain or loss
      /// </summary>
      public decimal totalGainLoss { get; set; }

      /// <summary>
      /// The total gain loss percentage
      /// </summary>
      public decimal totalGainLossPct { get; set; }

      /// <summary>
      /// The total price paid
      /// </summary>
      public decimal totalPricePaid { get; set; }

      /// <summary>
      /// The cash balance
      /// </summary>
      public decimal cashBalance { get; set; }
   }
}
