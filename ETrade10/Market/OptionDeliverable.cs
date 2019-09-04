namespace OkonkwoETrade10.Market
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/OptionDeliverable
   /// </summary>
   public class OptionDeliverable
   {
      public string rootSymbol { get; set; } /// Root symbol of option multiplier
      public string deliverableSymbol { get; set; } /// Symbol of share to be delivered
      public string deliverableTypeCode { get; set; } /// Type code of share to be delivered
      public string deliverableExchangeCode { get; set; } /// Exchange code of share to be delivered
      public decimal deliverableStrikePercent { get; set; } /// Strike percent of delivered product
      public decimal deliverableCILShares { get; set; } /// Number of CIL shares to be delivered
      public int deliverableWholeShares { get; set; } /// Number of whole shares to be distributed
   }
}
