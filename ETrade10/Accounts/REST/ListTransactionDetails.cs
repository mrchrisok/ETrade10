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
      public async Task<TransactionDetailsResponse> ListTransactionDetailsAsync(string accountIdKey, long tranId, TransactionDetailsParameters parameters)
      {
         string uri = ServerUri(EServer.Accounts) + $"{accountIdKey}/transactions/{tranId}";

         var requestParams = ConvertToDictionary(parameters);

         var response = await MakeRequestAsync<TransactionDetailsErrorResponse>(uri, requestParams: requestParams);

         return response.TransactionDetailsResponse;
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
      /// Numeric transaction ID
      /// </summary>
      public long transactionId { get; set; }

      /// <summary>
      /// Numeric account ID
      /// </summary>
      public string accountId { get; set; }

      /// <summary>
      /// Date of the specified transaction
      /// </summary>
      public long transactionDate { get; set; }

      /// <summary>
      /// The post date
      /// </summary>
      public long postDate { get; set; }

      /// <summary>
      /// Total cost of transaction, including commission if any
      /// </summary>
      public decimal amount { get; set; }

      /// <summary>
      /// The transaction description
      /// </summary>
      public string description { get; set; }

      /// <summary>
      /// User-defined category
      /// </summary>
      public Category category { get; set; }

      /// <summary>
      /// The brokerage involved in the transaction
      /// </summary>
      public Brokerage brokerage { get; set; }
   }

   /// <summary>
   /// The GET error response.
   /// </summary>
   public class TransactionDetailsErrorResponse : ErrorResponse
   {
   }
}
