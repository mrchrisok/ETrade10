using System.Collections.Generic;
using System.Threading.Tasks;
using OkonkwoETrade10.Common;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// The List Orders API provides the order details for a selected brokerage account based on the search criteria provided.
      /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definition/getOrders
      /// </summary>
      /// <param name="accountIdKey">The unique account key</param>
      /// <returns>An OptionExpireDateResponse object</returns>
      public static async Task<ListOrdersResponse> ListOrdersAsync(string accountIdKey, ListOrdersParameters parameters)
      {
         string uri = ServerUri(EServer.Accounts) + $"{accountIdKey}/orders";

         var requestParams = ConvertToDictionary(parameters);

         var response = await MakeRequestAsync<ListOrdersResponse, ListOrdersErrorResponse>(uri, requestParams: requestParams);

         return response;
      }

      public class ListOrdersParameters
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
   /// The success response received from accounts/accountID/orders
   /// </summary>
   public class ListOrdersResponse : Response
   {
      /// <summary>
      /// Specifies the desired starting point of the set of items to return. Used for paging
      /// </summary>
      public string marker { get; set; }

      /// <summary>
      /// The next order
      /// </summary>
      public string next { get; set; }

      public List<Order.Order> order { get; set; }

      /// <summary>
      /// The messages associated with the order
      /// </summary>
      public Messages messages { get; set; }
   }

   /// <summary>
   /// The error response received from accounts/accountID/orders
   /// </summary>
   public class ListOrdersErrorResponse : ErrorResponse
   {
   }
}
