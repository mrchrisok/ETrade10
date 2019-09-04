using System.Threading.Tasks;
using OkonkwoETrade10.REST.OrderRequest;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// The Place Changed Order API is used to place a modified order.
      /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definition/changeOrderPlace
      /// </summary>
      /// <param name="accountIdKey">The unique account key</param>
      /// <param name="orderId">The unique account key</param>
      /// <returns>a PostOrderResponse object</returns>
      public static async Task<PlaceOrderResponse> PlaceChangedOrderAsync(string accountIdKey, string orderId, PlaceOrderRequest request)
      {
         string uri = ServerUri(EServer.Accounts) + $"{accountIdKey}/orders/{orderId}/change/place";

         string body = ConvertToJSON(request);

         var response = await MakeRequestWithJSONBody<PlaceOrderResponse, PlaceChangedOrderErrorResponse>("POST", body, uri);

         return response;
      }
   }

   /// <summary>
   /// The POST error response received from accounts/accountID/orders
   /// </summary>
   public class PlaceChangedOrderErrorResponse : ErrorResponse
   {

   }
}
