namespace OkonkwoETrade10.Accounts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/account/api-balance-v1.html#/definitions/Margin
   /// </summary>
   public class Margin
   {
      /// <summary>
      /// The margin account cash open order reserve	
      /// </summary>
      public decimal dtCashOpenOrderReserve { get; set; }

      /// <summary>
      /// The margin account margin open order reserve	
      /// </summary>
      public decimal dtMarginOpenOrderReserve { get; set; }
   }
}
