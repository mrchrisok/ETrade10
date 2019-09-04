namespace OkonkwoETrade10.Common
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/Product
   /// </summary>
   public class Product
   {
      public string symbol { get; set; } // The symbol for which the quote details are being accessed
      public string securityType { get; set; } // The type code to identify the order or leg request BOND, EQ, INDX, MF, MMF, OPTN
      public string securitySubType { get; set; } // The subtype of the security
      public string callPut { get; set; } // The option type - either CALL or PUT   CALL, PUT
      public int expiryYear { get; set; } //   The four-digit year the option will expire
      public int expiryMonth { get; set; } //  The month(1-12) the option will expire
      public int expiryDay { get; set; } //   The day(1-31) the option will expire
      public decimal strikePrice { get; set; } //   The strike price for the option
      public string expiryType { get; set; } // The expiration type for the option
   }
}
