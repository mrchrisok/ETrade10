namespace OkonkwoETrade10.Order
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definitions/PortfolioMargin
   /// </summary>
   public class PortfolioMargin
   {
      /// <summary>
      /// The new house excess equity value for portfolio-margin eligible accounts
      /// </summary>
      public decimal houseExcessEquityNew { get; set; }

      /// <summary>
      /// The new house excess equity value for portfolio-margin eligible accounts
      /// </summary>
      public bool pmEligible { get; set; }

      /// <summary>
      /// The current house excess equity value for portfolio-margin eligible accounts
      /// </summary>
      public decimal houseExcessEquityCurr { get; set; }

      /// <summary>
      /// The change house excess equity value for portfolio-margin eligible accounts
      /// </summary>
      public decimal houseExcessEquityChange { get; set; }
   }
}
