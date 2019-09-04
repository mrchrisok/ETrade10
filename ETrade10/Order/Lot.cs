namespace OkonkwoETrade10.Order
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definitions/Lot
   /// </summary>
   public class Lot
   {
      /// <summary>
      /// The position lot details	
      /// </summary>
      public long id { get; set; }

      /// <summary>
      /// The number of shares to sell for the selected lot
      /// </summary>
      public decimal number { get; set; }
   }
}
