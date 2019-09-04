using System.Collections.Generic;

namespace OkonkwoETrade10.Order
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definitions/Lots
   /// </summary>
   public class Lots
   {
      /// <summary>
      /// The position lot details	
      /// </summary>
      public List<Lot> lot { get; set; }
   }
}
