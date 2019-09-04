namespace OkonkwoETrade10.Order
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definitions/DtBuyingPowerDetails
   /// </summary>
   public class DtBuyingPowerDetails : BuyingPowerDetails
   {
   }

   public abstract class BuyingPowerDetails
   {
      /// <summary>
      /// The total in the account that is not marginable
      /// </summary>
      public OrderBuyPowerEffect nonMarginable { get; set; }

      /// <summary>
      /// The total in the account that is marginable
      /// </summary>
      public OrderBuyPowerEffect marginable { get; set; }
   }
}
