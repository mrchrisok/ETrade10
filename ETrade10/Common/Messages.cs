using System.Collections.Generic;

namespace OkonkwoETrade10.Common
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/Messages
   /// </summary>
   public class Messages
   {
      /// <summary>
      /// The object for the message	
      /// </summary>
      public List<Message> message { get; set; }
   }
}
