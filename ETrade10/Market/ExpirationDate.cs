namespace OkonkwoETrade10.Market
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/ExpirationDate
   /// </summary>
   public class ExpirationDate
   {
      /// <summary>
      /// The four-digit year the option will expire	
      /// </summary>
      public short year { get; set; }

      /// <summary>
      /// The month (1-12) the option will expire
      /// </summary>
      public short month { get; set; }

      /// <summary>
      /// The day (1-31) the option will expire
      /// </summary>
      public int day { get; set; }

      /// <summary>
      /// Expiration type of the option
      /// </summary>
      public string expiryType { get; set; }
   }
}
