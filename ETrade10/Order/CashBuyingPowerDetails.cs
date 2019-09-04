namespace OkonkwoETrade10.Order
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definitions/CashBuyingPowerDetails
   /// </summary>
   public class CashBuyingPowerDetails
   {
      /// <summary>
      /// Settled Cash that has gone through the settlement process and now belongs to the customer's cash balance
      /// </summary>
      public OrderBuyPowerEffect settled { get; set; }

      /// <summary>
      /// Unsettled Cash, still in the settlement process, and not yet in customer's cash balance
      /// </summary>
      public OrderBuyPowerEffect settledUnsettled { get; set; }
   }
}
