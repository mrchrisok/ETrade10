using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using OkonkwoETrade10.Accounts;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// The Transaction APIs provide information about transactions for the selected brokerage account.
      /// https://apisb.etrade.com/docs/api/account/api-transaction-v1.html
      /// </summary>
      /// <param name="accountIdKey">summary will be retrieved for this account id</param>
      /// <returns>an AccountSummary object containing the account details</returns>
      public static async Task<List<Transaction>> ListTransactionsAsync(string accountIdKey, TransactionListParameters parameters)
      {
         string uri = ServerUri(EServer.Accounts) + $"{accountIdKey}/transactions";

         var requestParams = ConvertToDictionary(parameters);
         var headers = new WebHeaderCollection { { HttpRequestHeader.Accept, "application/json" } };

         var response = await MakeRequestAsync<TransactionListResponse, TransactionsListErrorResponse>(uri, null, headers, requestParams);

         return response.transactions;
      }

      public class TransactionListParameters
      {
         /// <summary>
         /// The earliest date to include in the date range, formatted as MMDDYYYY. History is available for two years.
         /// </summary>
         public string startDate { get; set; }

         /// <summary>
         /// The latest date to include in the date range, formatted as MMDDYYYY
         /// </summary>
         public string endDate { get; set; }

         /// <summary>
         /// The sort order request
         /// </summary>
         public string sortOrder { get; set; }

         /// <summary>
         /// Specifies the desired starting point of the set of items to return. Used for paging.	
         /// </summary>
         public string marker { get; set; }

         /// <summary>
         /// Number of transactions to return in the response. If not specified, defaults to 50. Used for paging.
         /// </summary>
         public int count { get; set; }
      }
   }

   /// <summary>
   /// The GET success response.
   /// </summary>
   public class TransactionListResponse : Response
   {
      /// <summary>
      /// The summary of the requested Account.
      /// </summary>
      public List<Transaction> transactions { get; set; }

      /// <summary>
      /// The URI for the next page of transactions for the request
      /// </summary>
      public string next { get; set; }

      /// <summary>
      /// The marker for the next page of transactions for the request
      /// </summary>
      public string marker { get; set; }

      /// <summary>
      /// The marker for the next page of transactions for the request
      /// </summary>
      public string pageMarkers { get; set; }

      /// <summary>
      /// Indicates if the current response is the last page of transactions that are included in the request
      /// </summary>
      public bool moreTransactions { get; set; }

      /// <summary>
      /// The count of transactions from the current page
      /// </summary>
      public int transactionCount { get; set; }

      /// <summary>
      /// The total count of transactions from all pages for the request
      /// </summary>
      public long totalCount { get; set; }
   }

   /// <summary>
   /// The GET error response.
   /// </summary>
   public class TransactionsListErrorResponse : ErrorResponse
   {
   }
}
