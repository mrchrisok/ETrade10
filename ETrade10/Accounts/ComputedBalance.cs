namespace OkonkwoETrade10.Accounts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/account/api-balance-v1.html#/definitions/ComputedBalance
   /// </summary>
   public class ComputedBalance
   {
      /// <summary>
      /// 
      /// </summary>
      public decimal cashAvailableForInvestment { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public decimal cashAvailableForWithdrawal { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public decimal totalAvailableForWithdrawal { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public decimal netCash { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public decimal cashBalance { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public decimal settledCashForInvestment { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public decimal unSettledCashForInvestment { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public decimal fundsWithheldFromPurchasePower { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public decimal fundsWithheldFromWithdrawal { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public decimal marginBuyingPower { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public decimal cashBuyingPower { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public decimal dtMarginBuyingPower { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public decimal dtCashBuyingPower { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public decimal marginBalance { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public decimal shortAdjustBalance { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public decimal regtEquity { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public decimal regtEquityPercent { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public decimal accountBalance { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public OpenCalls openCalls { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public RealTimeValues realTimeValues { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public PortfolioMargin portfolioMargin { get; set; }
   }
}
