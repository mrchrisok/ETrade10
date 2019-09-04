namespace OkonkwoETrade10.Accounts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/account/api-portfolio-v1.html#/definitions/PositionLot
   /// </summary>
   public class PositionLot
   {
      public long positionId { get; set; } //   The position ID
      public long positionLotId { get; set; } //The position lot ID
      public decimal price { get; set; }   //   The position lot price
      public int termCode { get; set; } //   The term code
      public decimal daysGain { get; set; }   //   The days gain
      public decimal daysGainPct { get; set; }   //   The days gain percentage
      public decimal marketValue { get; set; }   //   The market value
      public decimal totalCost { get; set; }   //   The total cost
      public decimal totalCostForGainPct { get; set; }   //   The total cost for the percentage gain
      public decimal totalGain { get; set; }   //   The total gain
      public int lotSourceCode { get; set; } //   The lot source code
      public decimal originalQty { get; set; }   //   The original quantity
      public decimal remainingQty { get; set; }   // The remaining quantity
      public decimal availableQty { get; set; }   //   The available quantity
      public long orderNo { get; set; } //   The order number
      public int legNo { get; set; } //   The leg number
      public long acquiredDate { get; set; } //   The date acquired
      public int locationCode { get; set; } //   The location code
      public decimal exchangeRate { get; set; }   //   The exchange rate
      public string settlementCurrency { get; set; }   // The settlement currency
      public string paymentCurrency { get; set; }   // The payment currency
      public decimal adjPrice { get; set; }   //   The adjusted price
      public decimal commPerShare { get; set; }   //   The commissions per share
      public decimal feesPerShare { get; set; }   //   The fees per share
      public decimal premiumAdj { get; set; }   //   The adjusted premium
      public int shortType { get; set; } //   The short type
   }
}
