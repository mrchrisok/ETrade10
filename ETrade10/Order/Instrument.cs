using OkonkwoETrade10.Common;

namespace OkonkwoETrade10.Order
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definitions/Instrument
   /// </summary>
   public class Instrument
   {
      /// <summary>
      /// The product details for the security
      /// </summary>
      public Product product { get; set; }

      /// <summary>
      /// The text description of the security being bought or sold
      /// </summary>
      public string symbolDescription { get; set; }

      /// <summary>
      /// The action that the broker is requested to perform
      /// </summary>
      public string orderAction { get; set; }

      /// <summary>
      /// The type of the quantity: QUANTITY, DOLLAR, ALL_I_OWN
      /// </summary>
      public string quantityType { get; set; }

      /// <summary>
      /// The number of shares to buy or sell
      /// </summary>
      public decimal quantity { get; set; }

      /// <summary>
      /// The number of shares to cancel ordering
      /// </summary>
      public decimal cancelQuantity { get; set; }

      /// <summary>
      /// The number of shares ordered
      /// </summary>
      public decimal orderedQuantity { get; set; }

      /// <summary>
      /// The number of shares filled
      /// </summary>
      public decimal filledQuantity { get; set; }

      /// <summary>
      /// The average execution price
      /// </summary>
      public decimal averageExecutionPrice { get; set; }

      /// <summary>
      /// The cost billed to the user to perform the requested action
      /// </summary>
      public decimal estimatedCommission { get; set; }

      /// <summary>
      /// The cost or proceeds, including broker commission, resulting from the requested action
      /// </summary>
      public decimal estimatedFees { get; set; }

      /// <summary>
      /// The bid price
      /// </summary>
      public decimal bid { get; set; }

      /// <summary>
      /// The ask price
      /// </summary>
      public decimal ask { get; set; }

      /// <summary>
      /// The last price
      /// </summary>
      public decimal lastprice { get; set; }

      /// <summary>
      /// The currency used for the order request 
      /// </summary>
      public string currency { get; set; }

      /// <summary>
      /// The object for the position lot
      /// </summary>
      public Lots lots { get; set; }

      /// <summary>
      /// The object for the mutual fund quantity	
      /// </summary>
      public MFQuantity mfQuantity { get; set; }

      /// <summary>
      /// The Options Symbology Initiative (OSI) key containing the option root symbol, expiration date, call/put indicator, and strike price
      /// </summary>
      public string osiKey { get; set; }

      /// <summary>
      /// The transaction for the mutual fund order BUY, SELL
      /// </summary>
      public string mfTransaction { get; set; }

      /// <summary>
      /// If TRUE, this is a reserve order meaning that only a limited number of shares will be publicly displayed instead of the entire order; this is done to avoid influencing other traders
      /// </summary>
      public bool reserveOrder { get; set; }

      /// <summary>
      /// The number of shares to be publicly displayed if this is a reserve order
      /// </summary>
      public decimal reserveQuantity { get; set; }
   }
}
