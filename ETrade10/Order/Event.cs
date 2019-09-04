using System.Collections.Generic;

namespace OkonkwoETrade10.Order
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definitions/Event
   /// </summary>
   public class Event
   {
      /// <summary>
      /// The name of the order event
      /// </summary>
      public string name { get; set; }

      /// <summary>
      /// The date and time of the order event
      /// </summary>
      public long dateTime { get; set; }

      /// <summary>
      /// The numeric ID for this order in the E*TRADE system
      /// </summary>
      public int orderNumber { get; set; }


      /// <summary>
      ///       The object for the instrument
      /// </summary>
      public List<Instrument> instrument { get; set; }
   }
}
