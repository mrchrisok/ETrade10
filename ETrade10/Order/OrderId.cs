namespace OkonkwoETrade10.Order
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definitions/OrderId
   /// </summary>
   public class OrderId
   {
      /// <summary>
      /// ID number assigned to this order	
      /// </summary>
      public long orderId { get; set; }

      /// <summary>
      /// The cash margin designation
      /// </summary>
      public string cashMargin { get; set; }
   }
}
