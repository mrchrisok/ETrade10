namespace OkonkwoETrade10.Order
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definitions/MFQuantity
   /// </summary>
   public class MFQuantity
   {
      /// <summary>
      /// The value of the cash quantity in the mutual fund	
      /// </summary>
      public decimal cash { get; set; }

      /// <summary>
      /// The value of the margin quantity in the mutual fund	
      /// </summary>
      public decimal margin { get; set; }

      /// <summary>
      /// The CUSIP value of the mutual fund symbol
      /// </summary>
      public string cusip { get; set; }
   }
}
