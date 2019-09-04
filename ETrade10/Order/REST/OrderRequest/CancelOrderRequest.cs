namespace OkonkwoETrade10.REST.OrderRequest
{
   public class CancelOrderRequest : Request
   {
      /// <summary>
      /// Order confirmation Id for the order placed.
      /// </summary>
      public long orderId { get; set; }
   }
}
