using System.Collections.Generic;

namespace OkonkwoETrade10.Order
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definitions/Events
   /// </summary>
   public class Events
   {
      /// <summary>
      /// The type of order event
      /// </summary>
      public List<Event> @event { get; set; }
   }
}
