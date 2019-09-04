namespace OkonkwoETrade10.Accounts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/account/api-balance-v1.html#/definitions/PortfolioMargin
   /// </summary>
   public class PortfolioMargin
   {
      /// <summary>
      /// The margin account cash open order reserve
      /// </summary>
      public decimal dtCashOpenOrderReserve { get; set; }

      /// <summary>
      /// The margin account margin open order reserve
      /// </summary>
      public decimal dtMarginOpenOrderReserve { get; set; }

      /// <summary>
      /// The liquidating equity
      /// </summary>
      public decimal liquidatingEquity { get; set; }

      /// <summary>
      /// The house excess equity
      /// </summary>
      public decimal houseExcessEquity { get; set; }

      /// <summary>
      /// The total house requirement
      /// </summary>
      public decimal totalHouseRequirement { get; set; }

      /// <summary>
      /// The excess equity minus the portfolio requirement
      /// </summary>
      public decimal excessEquityMinusRequirement { get; set; }

      /// <summary>
      /// The total margin requirements
      /// </summary>
      public decimal totalMarginRqmts { get; set; }

      /// <summary>
      /// The available excess equity
      /// </summary>
      public decimal availExcessEquity { get; set; }

      /// <summary>
      /// The excess equity
      /// </summary>
      public decimal excessEquity { get; set; }

      /// <summary>
      /// The open order reserve
      /// </summary>
      public decimal openOrderReserve { get; set; }

      /// <summary>
      /// The funds on hold
      /// </summary>
      public decimal fundsOnHold { get; set; }
   }
}
