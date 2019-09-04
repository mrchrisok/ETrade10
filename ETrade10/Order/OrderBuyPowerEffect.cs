namespace OkonkwoETrade10.Order
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definitions/OrderBuyPowerEffect
   /// </summary>
   public class OrderBuyPowerEffect
   {
      /// <summary>
      /// Current Buying Power, without including Open orders
      /// </summary>
      public decimal currentBp { get; set; }

      /// <summary>
      /// Open Order Reserve for the existing open orders
      /// </summary>
      public decimal currentOor { get; set; }

      /// <summary>
      /// Current Buying Power minus the CurrentOOR
      /// </summary>
      public decimal currentNetBp { get; set; }

      /// <summary>
      /// The current order impact on the account
      /// </summary>
      public decimal currentOrderImpact { get; set; }

      /// <summary>
      /// Buying Power after factoring in the Current Order
      /// </summary>
      public decimal netBp { get; set; }
   }
}
