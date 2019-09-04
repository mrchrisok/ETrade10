namespace OkonkwoETrade10.Common
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/Message
   /// </summary>
   public class Message
   {
      /// <summary>
      /// The text of the result message, indicating order status, success or failure, additional requirements that 
      /// must be met before placing the order, and so on. 
      /// Applications typically display this message to the user, which may result in further user action.
      /// </summary>
      public string description { get; set; }

      /// <summary>
      /// The standard numeric code of the result message. Refer to the Error Messages documentation for examples. 
      /// May optionally be displayed to the user, but is primarily intended for internal use.
      /// </summary>
      public int code { get; set; }

      /// <summary>
      /// The type used to identify the message
      /// </summary>
      public string type { get; set; }
   }
}
