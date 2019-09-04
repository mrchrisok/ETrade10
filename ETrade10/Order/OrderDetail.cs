using System.Collections.Generic;
using OkonkwoETrade10.Common;

namespace OkonkwoETrade10.Order
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definitions/OrderDetail
   /// </summary>
   public class OrderDetail
   {
      /// <summary>
      /// The numeric ID for this order in the E*TRADE system
      /// </summary>
      public int orderNumber { get; set; }

      /// <summary>
      /// The numeric account ID
      /// </summary>
      public string accountId { get; set; }

      /// <summary>
      /// The time of the order preview
      /// </summary>
      public long previewTime { get; set; }

      /// <summary>
      /// The time the order was placed(UTC)
      /// </summary>
      public long placedTime { get; set; }

      /// <summary>
      /// The time the order was executed(UTC)
      /// </summary>
      public long executedTime { get; set; }

      /// <summary>
      /// Total cost or proceeds, including commission
      /// </summary>
      public decimal orderValue { get; set; }

      /// <summary>
      /// The status of the order
      /// </summary>
      public string status { get; set; }

      /// <summary>
      /// The tyep of order being placed
      /// </summary>
      public string orderType { get; set; }

      /// <summary>
      /// The term for which the order is in effect
      /// </summary>
      public string orderTerm { get; set; }

      /// <summary>
      /// The type of pricing
      /// </summary>
      public decimal priceType { get; set; }

      /// <summary>
      /// The value of the price
      /// </summary>
      public decimal priceValue { get; set; }

      /// <summary>
      /// The highest price at which to buy or the lowest price at which to sell if specified in a limit order	
      /// </summary>
      public decimal limitPrice { get; set; }//

      /// <summary>
      /// The designated boundary price for a stop order
      /// </summary>
      public decimal stopPrice { get; set; }

      /// <summary>
      /// The designated boundary price for a stop-limit order
      /// </summary>
      public decimal stopLimitPrice { get; set; }

      /// <summary>
      /// Indicator to identify the trailing stop price type. Values: TRAILING_STOP_CNST, TRAILING_STOP_PRCT
      /// </summary>
      public string offsetType { get; set; }

      /// <summary>
      /// The stop value for trailing stop price types
      /// </summary>
      public decimal offsetValue { get; set; }

      /// <summary>
      /// The session in which the order will be placed. Values: REGULAR, EXTENDED
      /// </summary>
      public string marketSession { get; set; }

      /// <summary>
      /// The exchange where the order should be executed. Users may want to specify this if they believe they can get a better order fill at a specific exchange rather than relying on the automatic order routing system.
      /// </summary>
      public string routingDestination { get; set; }

      /// <summary>
      /// The bracketed limit price
      /// </summary>
      public decimal bracketedLimitPrice { get; set; }

      /// <summary>
      /// The initial stop price
      /// </summary>
      public decimal initialStopPrice { get; set; }

      /// <summary>
      /// The current trailing value. For trailing stop dollar orders, this is a fixed dollar amount. 
      /// For trailing stop percentage orders, this is the price reflected by the percentage selected.	
      /// </summary>
      public decimal trailPrice { get; set; }

      /// <summary>
      /// The price that an advanced order will trigger. 
      /// For example, if it is a $1 buy trailing stop, then the trigger price will be $1 above the last price.	
      /// </summary>
      public decimal triggerPrice { get; set; }

      /// <summary>
      /// For a conditional order, the price the condition is being compared against
      /// </summary>
      public decimal conditionPrice { get; set; }

      /// <summary>
      /// For a conditional order, the symbol that the condition is being compared against	
      /// </summary>
      public string conditionSymbol { get; set; }

      /// <summary>
      /// The type of comparison to be used in a conditional order	
      /// </summary>
      public string conditionType { get; set; }

      /// <summary>
      /// In a conditional order, the type of price being followed ASK, BID, LAST
      /// </summary>
      public string conditionFollowPrice { get; set; }

      /// <summary>
      /// The condition security type
      /// </summary>
      public string conditionSecurityType { get; set; }

      /// <summary>
      /// In the event of a change order request, the order ID of the order that is replacing a prior order.	
      /// </summary>
      public int replacedByOrderId { get; set; }

      /// <summary>
      /// In the event of a change order request, the order ID of the order that the new order is replacing.	
      /// </summary>
      public int replacesOrderId { get; set; }

      /// <summary>
      /// If TRUE, the transactions specified in the order must be executed all at once or not at all; default is FALSE	
      /// </summary>
      public bool allOrNone { get; set; }

      /// <summary>
      /// This parameter is required and must specify the numeric preview ID from the preview and the other parameters of this request must match the parameters of the preview.	
      /// </summary>
      public long previewId { get; set; }

      /// <summary>
      /// The object for the instrument
      /// </summary>
      public List<Instrument> instrument { get; set; }

      /// <summary>
      /// The object for the messages
      /// </summary>
      public Messages messages { get; set; }

      /// <summary>
      /// The preclearance code
      /// </summary>
      public string preClearanceCode { get; set; }

      /// <summary>
      /// The overrides restricted code
      /// </summary>
      public int overrideRestrictedCd { get; set; }

      /// <summary>
      /// The amount of the investment
      /// </summary>
      public decimal investmentAmount { get; set; }

      /// <summary>
      /// The position quantity
      /// </summary>
      public string positionQuantity { get; set; }

      /// <summary>
      /// Indicator to identify if automated investment planning is turned on or off
      /// </summary>
      public bool aipFlag { get; set; }

      /// <summary>
      /// Indicator of the execution guarantee of the order
      /// </summary>
      public string egQual { get; set; }

      /// <summary>
      /// Indicator flag to specify whether to reinvest profit on mutual funds
      /// </summary>
      public string reInvestOption { get; set; }

      /// <summary>
      /// The cost billed to the user to perform the requested action
      /// </summary>
      public decimal estimatedCommission { get; set; }

      /// <summary>
      /// The estimated fees
      /// </summary>
      public decimal estimatedFees { get; set; }

      /// <summary>
      /// The cost or proceeds, including broker commission, resulting from the requested action	
      /// </summary>
      public decimal estimatedTotalAmount { get; set; }

      /// <summary>
      /// The net price
      /// </summary>
      public decimal netPrice { get; set; }

      /// <summary>
      /// The net bid
      /// </summary>
      public decimal netBid { get; set; }

      /// <summary>
      /// The net ask
      /// </summary>
      public decimal netAsk { get; set; }

      /// <summary>
      /// The GCD
      /// </summary>
      public int gcd { get; set; }

      /// <summary>
      /// The ratio
      /// </summary>
      public string ratio { get; set; }

      /// <summary>
      /// The mutual fund price type
      /// </summary>
      public string mfpriceType { get; set; }
   }
}
