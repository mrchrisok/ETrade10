using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using OkonkwoETrade10.Accounts;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// Get the detailed balance information for a specified account for the current user.
      /// https://apisb.etrade.com/docs/api/account/api-balance-v1.html
      /// </summary>
      /// <param name="accountIdKey">The unique account key. Retrievable by calling the List Accounts API.</param>
      /// <param name="parameters">The account balance parameters</param>
      /// <returns>The information returned includes account type, option level, and details on up to four balances - account balance, margin account balance, day trade balance, and cash account balance.</returns>
      public async Task<BalanceResponse> GetAccountBalancesAsync(string accountIdKey, BalanceParameters parameters)
      {
         string uri = ServerUri(EServer.Accounts) + $"{accountIdKey}/balance";

         var requestParams = ConvertToDictionary(parameters);

         var response = await MakeRequestAsync<BalanceResponse, BalanceErrorResponse>(uri, requestParams: requestParams);
         return response;
      }

      public class BalanceParameters
      {
         /// <summary>
         /// The registered account type
         /// </summary>
         [DataMember(EmitDefaultValue = false)]
         public string accountType { get; set; }

         /// <summary>
         /// The account institution type for which the balance or information is requested
         /// </summary>
         public string instType { get; set; }

         /// <summary>
         /// Default is false. If true, fetches real time balance
         /// </summary>
         [DataMember(EmitDefaultValue = false)]
         public bool realTimeNAV { get; set; }
      }
   }

   /// <summary>
   /// The GET success response received from the accounts/accountID
   /// </summary>
   public class BalanceResponse : Response
   {
      /// <summary>
      /// The account ID for which the balance is requested
      /// </summary>
      public string accountId { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public string institutionType { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public long asOfDate { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public string accountType { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public OptionLevel optionLevel { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public string accountDescription { get; set; }

      /// <summary>
      /// The quote type indicator: 0 = QUOTE REALTIME, 1 = QUOTE DELAYED, 2 = QUOTE CLOSING, 3 = QUOTE AHT REALTIME, 4 = QUOTE AHT BEFORE OPEN, 5 = QUOTE AHT CLOSING, 6 = QUOTE NONE	
      /// </summary>
      public QuoteMode quoteMode { get; set; }

      /// <summary>
      /// The user's status as a day trader
      /// </summary>
      public string dayTraderStatus { get; set; }

      /// <summary>
      /// The account mode indicating the account's special privileges as a cash account, a margin account, and so on
      /// </summary>
      public string accountMode { get; set; }

      /// <summary>
      /// The description of the account for which the balance is requested
      /// </summary>
      public string accountDesc { get; set; }

      /// <summary>
      /// The open calls
      /// </summary>
      public List<OpenCalls> openCalls { get; set; }

      /// <summary>
      /// Designates that account is a cash account	
      /// </summary>
      public Cash cash { get; set; }

      /// <summary>
      /// Designates that account is a margin account	
      /// </summary>
      public Margin margin { get; set; }

      /// <summary>
      /// Designates that account is a lending account	
      /// </summary>
      public Lending lending { get; set; }

      /// <summary>
      /// Designates the computed balance of the account	
      /// </summary>
      public ComputedBalance compuatedBalance { get; set; }
   }

   /// <summary>
   /// The GET error response received from the accounts/accountID
   /// </summary>
   public class BalanceErrorResponse : ErrorResponse
   {
   }
}
