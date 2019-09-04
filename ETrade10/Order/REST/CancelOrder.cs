using System.Threading.Tasks;
using OkonkwoETrade10.Common;
using OkonkwoETrade10.REST.OrderRequest;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// The cancel order API is used to cancel an existing order.
      /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definition/cancelOrder
      /// </summary>
      /// <param name="accountIdKey">The unique account key</param>
      /// <returns>a CancelOrderResponse object</returns>
      public static async Task<CancelOrderResponse> CancelOrderAsync(string accountIdKey, CancelOrderRequest request)
      {
         string uri = ServerUri(EServer.Accounts) + $"{accountIdKey}/orders/cancel";

         //var order = new Dictionary<string, PlaceOrderRequest> { { "order", request } };
         string body = ConvertToJSON(request);

         var response = await MakeRequestWithJSONBody<CancelOrderResponse, CancelOrderErrorResponse>("POST", body, uri);

         return response;
      }
   }

   /// <summary>
   /// The POST success response
   /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definitions/CancelOrderResponse
   /// </summary>
   public class CancelOrderResponse : Response
   {
      /// <summary>
      /// The numeric account ID for the cancelled order
      /// </summary>
      public string accountId { get; set; }

      /// <summary>
      /// The order ID
      /// </summary>
      public long orderId { get; set; }

      /// <summary>
      /// The time, in Epoch time, that the cancel request was submitted
      /// </summary>
      public long cancelTime { get; set; }

      /// <summary>
      /// The messages relating to the order cancellation
      /// </summary>
      public Messages messages { get; set; }
   }

   /// <summary>
   /// The error response received from accounts/accountID/orders
   /// </summary>
   public class CancelOrderErrorResponse : ErrorResponse
   {
   }
}
