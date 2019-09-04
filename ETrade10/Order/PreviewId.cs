namespace OkonkwoETrade10.Order
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definitions/PreviewId
   /// </summary>
   public class PreviewId
   {
      /// <summary>
      /// The preview ID number. It must be used with place order within 3 minutes
      /// </summary>
      public long previewId { get; set; }

      /// <summary>
      /// The margin level designation
      /// </summary>
      public string cashMargin { get; set; }
   }
}
