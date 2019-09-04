using System.Collections.Generic;

namespace OkonkwoETrade10.Order
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definitions/Order
   /// </summary>
   public class Order : IOrder
   {
      /// <summary>
      /// ID number assigned to this order
      /// </summary>
      public long orderId { get; set; }

      /// <summary>
      /// The order details
      /// </summary>
      public string details { get; set; }

      /// <summary>
      /// The type of order being placed
      /// </summary>
      public string orderType { get; set; }

      /// <summary>
      /// The total order value
      /// </summary>
      public decimal totalOrderValue { get; set; }

      /// <summary>
      /// The order details
      /// </summary>
      public decimal totalCommission { get; set; }

      /// <summary>
      /// The order confirmation ID for the placed order
      /// </summary>
      public List<OrderDetail> orderDetail { get; set; }

      /// <summary>
      /// The events in the placed order
      /// </summary>
      public Events events { get; set; }
   }

   public interface IOrder
   {
      long orderId { get; set; }
      string orderType { get; set; }
   }
}
