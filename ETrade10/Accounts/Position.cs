using System.Collections.Generic;
using OkonkwoETrade10.Common;

namespace OkonkwoETrade10.Accounts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/account/api-portfolio-v1.html#/definitions/Position
   /// </summary>
   public class Position
   {
      public long positionId { get; set; }   //The position ID
      public string accountId { get; set; }   // Numeric account ID
      public Product product { get; set; }   //  The product

      /// <summary>
      /// The Options Symbology Initiative (OSI) key containing the option root symbol, expiration date, call/put indicator, and strike price
      /// </summary>
      public string osiKey { get; set; }
      public string symbolDescription { get; set; }   // The symbol description
      public long dateAcquired { get; set; }   //   The date the position was acquired
      public decimal pricePaid { get; set; }   //   The price paid for the position
      public decimal price { get; set; }   //; }   //   The price of the position
      public decimal commissions { get; set; }   // The commissions paid for the position
      public decimal otherFees { get; set; }   //   The other fees paid to acquire the position
      public decimal quantity { get; set; }   //   The quantity
      public string positionIndicator { get; set; }   // The position indicator  TYPE1, TYPE2, TYPE5, UNDEFINED
      public string positionType { get; set; }   // The position type
      public decimal change { get; set; }   //   The change
      public decimal changePct { get; set; }   //   The percentage change
      public decimal daysGain { get; set; }   // The day's gain	
      public decimal daysGainPct { get; set; }   //   The percentage day's gain	
      public decimal marketValue { get; set; }   //   The market value
      public decimal totalCost { get; set; }   // The total cost
      public decimal totalGain { get; set; }   //   The total gain
      public decimal totalGainPct { get; set; }   // The total gain percentage
      public decimal pctOfPortfolio { get; set; }   // The percentage of the portfolio
      public decimal costPerShare { get; set; }   //   The cost per share
      public decimal todayCommissions { get; set; }   //   Today's total commissions	
      public decimal todayFees { get; set; }   //   Today's total fees	
      public decimal todayPricePaid { get; set; }   //   Today's total price paid	
      public decimal todayQuantity { get; set; }   //   Today's total quantity	
      public string quotestatus { get; set; }   // The quote type
      public long dateTimeUTC { get; set; }   //   The date and time in UTC
      public decimal adjPrevClose { get; set; }   // The previous adjusted close
      public PerformanceView performance { get; set; }   // The performance view
      public FundamentalView fundamental { get; set; }   //   The fundamental view
      public OptionsWatchView optionsWatch { get; set; }   // The options watch view
      public QuickView quick { get; set; }   // The quick view
      public CompleteView complete { get; set; }   //   The complete view
      public string lotsDetails { get; set; }   // The lots details
      public string quoteDetails { get; set; }   // The quote details
      public List<PositionLot> positionLot { get; set; }   //  The position lot
   }
}
