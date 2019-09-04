namespace OkonkwoETrade10.Market
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/SaleChargeValues
   /// </summary>
   public class SaleChargeValues
   {
      /// <summary>
      /// The sales charge for investing in the mutual fund expressed as a low-high range (usually the sales charge is between 3-6%)
      /// </summary>
      public string lowhigh { get; set; }

      /// <summary>
      /// The percentage of the investment spent on the sales charge
      /// </summary>
      public string percent { get; set; }
   }
}
