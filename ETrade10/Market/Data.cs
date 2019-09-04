namespace OkonkwoETrade10.Market
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/Data
   /// </summary>
   public class Data
   {
      /// <summary>
      /// The market symbol for the security
      /// </summary>
      public string symbol { get; set; }

      /// <summary>
      /// The text description of the security
      /// </summary>
      public string description { get; set; }

      /// <summary>
      /// The symbol type
      /// </summary>
      public long type { get; set; }
   }
}
