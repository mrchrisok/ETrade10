using System.Threading.Tasks;
using OkonkwoETrade10.Order.REST.OrderRequest;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// The Preview Changed order API is used to preview a modified order.
      /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definition/changeOrderPreview
      /// </summary>
      /// <param name="accountIdKey">The unique account key</param>
      /// <param name="orderId">The order Id</param>
      /// <param name="request">The body of the preview order request</param>
      /// <returns>a PostOrderResponse object</returns>
      public async Task<PreviewOrderResponse> ChangePreviewedOrderAsync(string accountIdKey, string orderId, PreviewOrderRequest request)
      {
         string uri = ServerUri(EServer.Accounts) + $"{accountIdKey}/orders/{orderId}/change/preview";

         //var order = new Dictionary<string, PlaceOrderRequest> { { "order", request } };
         string body = ConvertToJSON(request);

         var response = await MakeRequestWithJSONBody<PreviewOrderResponse, ChangePreviewOrderErrorResponse>("POST", body, uri);

         return response;
      }
   }

   /// <summary>
   /// The error response received from accounts/{accountIdKey}/orders/{orderId}/change/preview
   /// </summary>
   public class ChangePreviewOrderErrorResponse : ErrorResponse
   {
   }
}
