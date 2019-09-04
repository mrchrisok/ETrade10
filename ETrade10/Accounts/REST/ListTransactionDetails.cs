using System.Net;
using System.Threading.Tasks;
using OkonkwoETrade10.Accounts;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// Get transaction details for the specified transaction (transactionId). 
      /// If a transactionId is provided, no additional path params should be specified in the URI. 
      /// API should fail with 404 if any path param is specified after activityId. 
      /// In order to make requests around the specific break out transaction types within the Transaction API, 
      /// simply append the title of the Transaction Category to the end of the path. This will provide you with 
      /// only transactions of that type so that you can build functionality and interact with subsets of data. 
      /// Possible transaction sub-types include: Trades, Withdrawals, Cash.
      /// https://apisb.etrade.com/docs/api/account/api-transaction-v1.html#/definition/getTransactionDetails
      /// </summary>
      /// <param name="accountIdKey">summary will be retrieved for this account id</param>
      /// <param name="tranId">the transaction identifier</param>
      /// <returns>the transaction details for the specified transaction (transactionId)</returns>
      public static async Task<Transaction> ListTransactionDetailsAsync(string accountIdKey, long tranId, TransactionDetailsParameters parameters)
      {
         string uri = ServerUri(EServer.Accounts) + $"{accountIdKey}/transactions/{tranId}";

         var requestParams = ConvertToDictionary(parameters);
         var headers = new WebHeaderCollection { { HttpRequestHeader.Accept, "application/json" } };

         var response = await MakeRequestAsync<TransactionDetailsResponse, TransactionDetailsErrorResponse>(uri, null, headers, requestParams);

         return response.transaction;
      }

      public class TransactionDetailsParameters
      {
         /// <summary>
         /// storage location for older transactions
         /// </summary>
         public string storeId { get; set; }
      }
   }

   /// <summary>
   /// The GET success response.
   /// </summary>
   public class TransactionDetailsResponse : Response
   {
      /// <summary>
      /// The summary of the requested Account.
      /// </summary>
      public Transaction transaction { get; set; }
   }

   /// <summary>
   /// The GET error response.
   /// </summary>
   public class TransactionDetailsErrorResponse : ErrorResponse
   {
   }
}
