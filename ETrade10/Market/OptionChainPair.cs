namespace OkonkwoETrade10.Market
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/OptionChainPair
   /// </summary>
   public class OptionChainPair
   {
      /// <summary>
      /// The option call in the option chain pair
      /// </summary>
      public OptionDetails optioncall { get; set; }

      /// <summary>
      /// The option put in the option chain pair
      /// </summary>
      public OptionDetails optionPut { get; set; }

      /// <summary>
      /// Determines whether the response will contain calls(CALLONLY), puts(PUTONLY), or both(CALLPUT)
      /// </summary>
      public string pairType { get; set; }
   }
}
