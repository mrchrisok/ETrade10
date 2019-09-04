namespace OkonkwoETrade10.Market
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/Values
   /// </summary>
   public class Values
   {
      /// <summary>
      /// When the dollar amount of mutual fund purchases reaches a specified level, the sales load decreases. 
      /// This field stores the minimum investment level at which the discount becomes available.
      /// </summary>
      public string low { get; set; }

      /// <summary>
      /// The maximum investment level at which the discount becomes available
      /// </summary>
      public string high { get; set; }

      /// <summary>
      /// he sales load percentage for amounts between the low and high values
      /// </summary>
      public string percent { get; set; }
   }
}
