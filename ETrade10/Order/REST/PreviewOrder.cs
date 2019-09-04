using System.Collections.Generic;
using System.Threading.Tasks;
using OkonkwoETrade10.Common;
using OkonkwoETrade10.Order;
using OkonkwoETrade10.Order.REST.OrderRequest;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// The Preview Order API is used to submit an order request for preview before placing it.
      /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definition/orderPreview
      /// </summary>
      /// <param name="accountIdKey">The unique account key</param>
      /// <returns>a PostOrderResponse object</returns>
      public static async Task<PreviewOrderResponse> PreviewOrderAsync(string accountIdKey, PreviewOrderRequest request)
      {
         string uri = ServerUri(EServer.Accounts) + $"{accountIdKey}/orders/preview";

         //var order = new Dictionary<string, PlaceOrderRequest> { { "order", request } };
         string body = ConvertToJSON(request);

         var response = await MakeRequestWithJSONBody<PreviewOrderResponse, PreviewOrderErrorResponse>("POST", body, uri);

         return response;
      }

      public class PreviewOrderParameters
      {
         /// <summary>
         /// Specifies the desired starting point of the set of items to return. Used for paging as described in the Notes below.
         /// </summary>
         public string marker { get; set; }

         /// <summary>
         /// Number of transactions to return in the response.
         /// If not specified, defaults to 25 and maximum count is 100. Used for paging.
         /// </summary>
         public int count { get; set; }

         /// <summary>
         /// The status
         /// </summary>
         public string status { get; set; }

         /// <summary>
         /// The earliest date to include in the date range, formatted as MMDDYYYY. 
         /// History is available for two years. Both fromDate and toDate should be provided, toDate should be greater than fromDate.	
         /// </summary>
         public string fromDate { get; set; }

         /// <summary>
         /// The latest date to include in the date range, formatted as MMDDYYYY. 
         /// Both fromDate and toDate should be provided, toDate should be greater than fromDate.	
         /// </summary>  	
         public string toDate { get; set; }

         /// <summary>
         /// The market symbol for the security being bought or sold. 
         /// API supports only 25 symbols seperated by delimiter " , ".	
         /// </summary>
         public string symbol { get; set; }

         /// <summary>
         /// The security type EQ, OPTN, BOND, MF, MMF
         /// </summary>
         public string securityType { get; set; }

         /// <summary>
         /// Type of transaction ATNM, BUY, SELL, SELL_SHORT, BUY_TO_COVER, MF_EXCHANGE
         /// </summary>

         public string transactionType { get; set; }

         /// <summary>
         /// Session in which the equity order will be place REGULAR, EXTENDED
         /// </summary>
         public string marketSession { get; set; }
      }
   }

   /// <summary>
   /// The POST success response
   /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definitions/PreviewOrderResponse
   /// </summary>
   public class PreviewOrderResponse : Response
   {
      /// <summary>
      /// The type of order being placed
      /// </summary>
      public decimal orderType { get; set; }

      /// <summary>
      /// The object for the message list
      /// </summary>
      public Messages messageList { get; set; }

      /// <summary>
      /// The total order value
      /// </summary>
      public decimal totalOrderValue { get; set; }

      /// <summary>
      /// The total commission
      /// </summary>
      public decimal totalCommission { get; set; }

      /// <summary>
      /// The details for the order
      /// </summary>
      public List<OrderDetail> order { get; set; }

      /// <summary>
      /// This parameter is required and must specify the numeric preview ID from the preview and the other parameters of this request must match the parameters of the preview.
      /// </summary>
      public List<PreviewId> previewIds { get; set; }

      /// <summary>
      /// The preview time
      /// </summary>
      public long previewTime { get; set; }

      /// <summary>
      /// Indicator flag identifying whether daylight savings time is applicable or not
      /// </summary>
      public bool dstFlag { get; set; }

      /// <summary>
      /// The numeric account ID
      /// </summary>
      public string accountId { get; set; }

      /// <summary>
      /// The code that designates the applicable options level
      /// </summary>
      public int optionLevelCd { get; set; }

      /// <summary>
      /// The code that designates the applicable margin level
      /// </summary>
      public string marginLevelCd { get; set; }

      /// <summary>
      /// The portfolio margin details for the user
      /// </summary>
      public PortfolioMargin portfolioMargin { get; set; }

      /// <summary>
      /// Indicator flag identifying whether user is an E*TRADE employee
      /// </summary>
      public bool isEmployee { get; set; }

      /// <summary>
      /// The commission message
      /// </summary>
      public string commissionMessage { get; set; }

      /// <summary>
      /// The disclosure designation
      /// </summary>
      public Disclosure disclosure { get; set; }

      /// <summary>
      /// A reference number generated by the developer used to ensure that a duplicate order is not being submitted. 
      /// This ID may be any value of 20 or less alphanumeric characters, but it must be unique within this account. 
      /// This field does not appear in any API responses.	
      /// </summary>
      public string clientOrderId { get; set; }

      /// <summary>
      /// Margin Buying Power Details for the user
      /// </summary>
      public MarginBuyingPowerDetails marginBpDetails { get; set; }

      /// <summary>
      /// Cash Buying Power Details for the user
      /// </summary>
      public CashBuyingPowerDetails cashBpDetails { get; set; }

      /// <summary>
      /// Day Trading Buying Power Details for the user
      /// </summary>
      public DtBuyingPowerDetails dtBpDetails { get; set; }
   }

   /// <summary>
   /// The error response received from accounts/accountID/orders
   /// </summary>
   public class PreviewOrderErrorResponse : ErrorResponse
   {
   }
}
